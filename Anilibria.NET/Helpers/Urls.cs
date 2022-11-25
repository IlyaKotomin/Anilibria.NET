using Anilibria.NET.Builders;
using Anilibria.NET.Models;

namespace Anilibria.NET.Helpers
{
    /// <summary>
    /// Helper calss, use to get <see cref="Uri"/>s
    /// </summary>
    internal static class Urls
    {
        #region ROOT URLS

        /// <summary>
        /// Anilibria API url
        /// </summary>
        public const string API_ROOT_URL = "https://api.anilibria.tv/v2";

        /// <summary>
        /// Anilibria website url
        /// </summary>
        public const string SITE_ROOT_URL = "https://www.anilibria.tv";

        #endregion

        #region PUBLIC DATA URLS


        /// <param name="id">Title id</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.Title"/></returns>
        internal static Uri GetTitleUri(int id) =>
            new Uri($"{API_ROOT_URL}/getTitle?id={id}&remove=player,torrents,posters");


        /// <param name="code">Title code</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.Title"/></returns>
        internal static Uri GetTitleUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code_list={code}&remove=player,torrents,posters");


        /// <param name="ids">Titles ids</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.Title"/>s</returns>
        internal static Uri GetTitlesUri(int[] ids) =>
            new Uri($"{API_ROOT_URL}/getTitles?id_list={string.Join(",", ids)}&remove=player,torrents,posters");


        /// <param name="codes">Titles codes</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.Title"/>s</returns>
        internal static Uri GetTitlesUri(string[] codes) =>
            new Uri($"{API_ROOT_URL}/getTitles?codes={string.Join(",", codes)}&remove=player,torrents,posters");


        /// <param name="id">Title id</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.TorrentsModel.Torrent"/></returns>
        internal static Uri GetTitleTorrentUri(int id) =>
            new Uri($"{API_ROOT_URL}/getTitle?id={id}&filter=torrents");


        /// <param name="code">Title code</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.TorrentsModel.Torrent"/></returns>
        internal static Uri GetTitleTorrentUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&filter=torrents");


        /// <param name="code">Title code</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.PlayerModel.Player"/></returns>
        internal static Uri GetTitlePlayerUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&filter=player&playlist_type=array");


        /// <param name="code">Title code</param>
        /// <returns><see cref="Uri"/> of <see cref="Models.TitleModel.PostersModel.Posters"/></returns>
        internal static Uri GetTitlePostersUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&filter=posters");


        /// <param name="limit">Response titles limit</param>
        /// <param name="after">Response after N titles</param>
        /// <returns><see cref="Uri"/> of Updated titles</returns>
        internal static Uri GetTitlesUpdatesUri(int limit = 5, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getUpdates?remove=player,torrents,posters&after={after}&limit={limit}");


        /// <param name="dateTime">Change Date</param>
        /// <param name="after">Response after N titles</param>
        /// <returns><see cref="Uri"/> of changed titles</returns>
        internal static Uri GetTitlesChangesUri(DateTime dateTime, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getChanges?remove=player,torrents,posters&" +
                $"after={after}&since={((DateTimeOffset)dateTime).ToUnixTimeSeconds()}");


        /// <param name="days">List of days</param>
        /// <returns><see cref="Uri"/> of schedule in selected days</returns>
        internal static Uri GetTitlesScheduleUri(int[] days) =>
            new Uri($"{API_ROOT_URL}/getSchedule?remove=player,torrents,posters&days={string.Join(",", days)}");


        /// <returns><see cref="Uri"/> of changing Nodes</returns>
        internal static Uri GetCachingNodesUri() =>
            new Uri($"{API_ROOT_URL}/getCachingNodes");


        /// <returns>Random title <see cref="Uri"/></returns>
        internal static Uri GetRandomeTitleUri() =>
            new Uri($"{API_ROOT_URL}/getRandomTitle");


        /// <param name="dateTime">Post date limit</param>
        /// <param name="limit">Posts limin in response</param>
        /// <param name="after">Response after N posts</param>
        /// <returns></returns>
        internal static Uri GetYouTubeUri(DateTime dateTime, int limit = 5, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getYouTube?limit={limit}&after={after}&since={((DateTimeOffset)dateTime).ToUnixTimeSeconds()}");


        /// <param name="dateTime">Posts after this date</param>
        /// <param name="limit">Posts limit in response</param>
        /// <param name="after">Posts in response after N posts</param>
        /// <returns><see cref="Uri"/> of feed</returns>
        internal static Uri GetFeedUri(DateTime dateTime, int limit = 5, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getFeed?limit={limit}&after={after}&since={((DateTimeOffset)dateTime).ToUnixTimeSeconds()}");


        /// <returns><see cref="Uri"/> of anime years</returns>
        internal static Uri GetAnimeYearsUri() =>
            new Uri($"{API_ROOT_URL}/getYears");


        /// <param name="sortingType">Type of sorting</param>
        /// <returns><see cref="Uri"/> of genres</returns>
        internal static Uri GetAnimeGenresUri(GenresSortingType sortingType) =>
            new Uri($"{API_ROOT_URL}/getGenres?sorting_type={(int)sortingType}");


        /// <param name="queryBuilder">Builder of search query</param>
        /// <returns><see cref="Uri"/> of serach</returns>
        internal static Uri GetSearchTitlesUri(SearchQueryBuilder queryBuilder) =>
            new Uri($"{API_ROOT_URL}{queryBuilder.Build()}");

        #endregion

        #region CLIENT DATA URLS

        /// <param name="token">Anilibria user token</param>
        /// <returns><see cref="Uri"/> of favorite title of user</returns>
        internal static Uri GetFavoriteTitles(string token) =>
            new Uri($"{API_ROOT_URL}/getFavorites?session={token}&remove=player,torrents,posters");


        #endregion
    }
}
