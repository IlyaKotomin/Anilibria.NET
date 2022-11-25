using Anilibria.NET.Builders;
using Anilibria.NET.Helpers;
using Anilibria.NET.Models;
using Anilibria.NET.Models.TitleModel;

namespace Anilibria.NET.Client
{
    /// <summary>
    /// Static Anilibria client with out loggin system.
    /// Use this to get titles, youtube posts and feed from anilibria and other different things
    /// </summary>
    public static class AnilibriaAPI
    {
        #region Http Client

        /// <summary>
        /// Http client which will got and post data
        /// </summary>
        internal static HttpClient HttpClient = new HttpClient();

        #endregion



        #region Titles


        /// <summary>
        /// Returns title by id
        /// </summary>
        /// <param name="id">Title ID</param>
        /// <returns><see cref="Title"/></returns>
        public static Task<Title> GetTitleAsync(int id) =>
            Utilities.GetData<Title>(HttpClient, Urls.GetTitleUri(id).AbsoluteUri);


        /// <summary>
        /// Returns title by code
        /// </summary>
        /// <param name="code">Title code</param>
        /// <returns><see cref="Title"/></returns>
        public static Task<Title> GetTitleAsync(string code) =>
            Utilities.GetData<Title>(HttpClient, Urls.GetTitleUri(code).AbsoluteUri);


        /// <summary>
        /// Returns titles by codes
        /// </summary>
        /// <param name="codes">Title codes</param>
        /// <returns><see cref="Title"/></returns>
        public static Task<Title[]> GetTitlesAsync(string[] codes) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUri(codes).AbsoluteUri);


        /// <summary>
        /// Returns titles by ids
        /// </summary>
        /// <param name="ids">Title ids</param>
        /// <returns><see cref="Title[]"/></returns>
        public static Task<Title[]> GetTitlesAsync(int[] ids) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUri(ids).AbsoluteUri);


        /// <summary>
        /// Returns updated titles
        /// </summary>
        /// <param name="limit">Titles limit in respose</param>
        /// <param name="after">Return title after this N</param>
        /// <returns>updated <see cref="Title[]"/>s</returns>
        public static Task<Title[]> GetTitlesUpdatesAsync(int limit = 5, int after = 0) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesUpdatesUri(limit, after).AbsoluteUri);


        /// <summary>
        /// Returns changed titles
        /// </summary>
        /// <param name="dateTime">Changes after date</param>
        /// <param name="after">Returns titles after this index</param>
        /// <returns>changed <see cref="Title[]"/></returns>
        public static Task<Title[]> GetTitlesChangesAsync(DateTime dateTime, int after = 0) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetTitlesChangesUri(dateTime, after).AbsoluteUri);
        

        /// <summary>
        /// Returns random <see cref="Title"/>
        /// </summary>
        /// <returns>Random <see cref="Title"/></returns>
        public static Task<Title> GetRandomTitleAsync() =>
            Utilities.GetData<Title>(HttpClient, Urls.GetRandomeTitleUri().AbsoluteUri);


        /// <summary>
        /// Search titles using <see cref="SearchQueryBuilder"/>
        /// </summary>
        /// <param name="queryBuilder">Query builder for search</param>
        /// <returns></returns>
        public static Task<Title[]> SearchTitlesAsync(SearchQueryBuilder queryBuilder) =>
            Utilities.GetData<Title[]>(HttpClient, Urls.GetSearchTitlesUri(queryBuilder).AbsoluteUri);


        #endregion



        #region Other


        /// <summary>
        /// Returns schedules of days from list
        /// </summary>
        /// <param name="days">List of days for which you want to see the schedule</param>
        /// <returns><see cref="Schedule[]"/> of days</returns>
        public static Task<Schedule[]> GetTitlesScheduleAsync(int[] days) =>
            Utilities.GetData<Schedule[]>(HttpClient, Urls.GetTitlesScheduleUri(days).AbsoluteUri);


        /// <summary>
        /// Returns change nodes as <see cref="string"/>s
        /// </summary>
        /// <returns>Change nodes as <see cref="string"/>s</returns>
        public static Task<string[]> GetCachingNodesAsync() =>
            Utilities.GetData<string[]>(HttpClient, Urls.GetCachingNodesUri().AbsoluteUri);


        /// <summary>
        /// Returns youtube posts (<see cref="YouTubePost"/>)
        /// </summary>
        /// <param name="dateTime">Search youtube posts after that date</param>
        /// <param name="limit">Limit of posts in response</param>
        /// <param name="after">Response posts after that index</param>
        /// <returns><see cref="YouTubePost"/>s</returns>
        public static Task<YouTubePost[]> GetYouTubePostsAsync(DateTime dateTime, int limit = 5, int after = 0) =>
            Utilities.GetData<YouTubePost[]>(HttpClient, Urls.GetYouTubeUri(dateTime, limit, after).AbsoluteUri);


        /// <summary>
        /// Returns feed from anilibria.tv
        /// </summary>
        /// <param name="dateTime">Feed after that date</param>
        /// <param name="limit">Limit of posts in response</param>
        /// <param name="after">Response posts after that index</param>
        /// <returns></returns>
        public static Task<Feed[]> GetFeedAsync(DateTime dateTime, int limit = 5, int after = 0) =>
            Utilities.GetData<Feed[]>(HttpClient, Urls.GetFeedUri(dateTime, limit, after).AbsoluteUri);


        /// <summary>
        /// Returns all years of anime which anilibria translated
        /// </summary>
        /// <returns>Years list as <see cref="int"/></returns>
        public static Task<int[]> GetAnimeYearsAsync() =>
            Utilities.GetData<int[]>(HttpClient, Urls.GetAnimeYearsUri().AbsoluteUri);


        /// <summary>
        /// Returns all genres as <see cref="string"/> array
        /// </summary>
        /// <param name="sortingType">Sorting type, see more in <see cref="GenresSortingType"/></param>
        /// <returns>genres as <see cref="string"/> array</returns>
        public static Task<string[]> GetGenresAsync(GenresSortingType sortingType) =>
            Utilities.GetData<string[]>(HttpClient, Urls.GetAnimeGenresUri(sortingType).AbsoluteUri);


        #endregion
    }
}
