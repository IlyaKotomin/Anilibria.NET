using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;
using System.Security;

namespace Anilibria.NET
{
    internal static class Urls
    {
        #region ROOT URLS

        /// <summary>
        /// Anilibria API url
        /// </summary>
        public const string API_ROOT_URL = "https://api.anilibria.tv/v2";

        /// <summary>
        /// Anilibria site url
        /// </summary>
        public const string SITE_ROOT_URL = "https://www.anilibria.tv";

        #endregion

        #region DATA URLS

        internal static Uri GetTitleUri(int id) =>
            new Uri($"{API_ROOT_URL}/getTitle?id={id}&remove=player,torrents,posters");

        internal static Uri GetTitleUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code_list={code}&remove=player,torrents,posters");

        internal static Uri GetTitlesUri(int[] id) =>
            new Uri($"{API_ROOT_URL}/getTitles?id_list={string.Join(",", id)}&remove=player,torrents,posters");

        internal static Uri GetTitlesUri(string[] codes) =>
            new Uri($"{API_ROOT_URL}/getTitles?codes={string.Join(",", codes)}&remove=player,torrents,posters");

        internal static Uri GetTitleTorrentUri(int id) =>
            new Uri($"{API_ROOT_URL}/getTitle?id={id}&filter=torrents");

        internal static Uri GetTitleTorrentUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&filter=torrents");

        internal static Uri GetTitlePlayerUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&filter=player&playlist_type=array");

        internal static Uri GetTitlePostersUri(string code) =>
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&filter=posters");

        internal static Uri GetTitlesUpdatesUri(int limit = 5, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getUpdates?remove=player,torrents,posters&after={after}&limit={limit}");

        internal static Uri GetTitlesChangesUri(DateTime dateTime, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getChanges?remove=player,torrents,posters&" +
                $"after={after}&since={((DateTimeOffset)dateTime).ToUnixTimeSeconds()}");

        internal static Uri GetTitlesScheduleUri(int[] days) =>
            new Uri($"{API_ROOT_URL}/getSchedule?remove=player,torrents,posters&days={string.Join(",", days)}");

        internal static Uri GetCachingNodesUri() =>
            new Uri($"{API_ROOT_URL}/getCachingNodes");

        internal static Uri GetRandomeTitleUri() =>
            new Uri($"{API_ROOT_URL}/getRandomTitle");

        internal static Uri GetYouTubeUri(DateTime dateTime, int limit = 5, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getYouTube?limit={limit}&after={after}&since={((DateTimeOffset)dateTime).ToUnixTimeSeconds()}");

        internal static Uri GetFeedUri(DateTime dateTime, int limit = 5, int after = 0) =>
            new Uri($"{API_ROOT_URL}/getFeed?limit={limit}&after={after}&since={((DateTimeOffset)dateTime).ToUnixTimeSeconds()}");

        internal static Uri GetAnimeYearsUri() =>
            new Uri($"{API_ROOT_URL}/getYears");

        internal static Uri GetAnimeGenresUri(GenresSortingType sortingType) =>
            new Uri($"{API_ROOT_URL}/getGenres?sorting_type={(int)sortingType}");

        internal static Uri GetSearchTitlesUri(SearchQueryBuilder queryBuilder) =>
            new Uri($"{API_ROOT_URL}{queryBuilder.Build()}");

        #endregion
    }
}
