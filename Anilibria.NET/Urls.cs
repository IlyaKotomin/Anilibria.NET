namespace Anilibria.NET
{
    public class Urls
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

        public static Uri GetTitleById(int id) =>
            new Uri($"{API_ROOT_URL}/getTitle?id={id}");

        #endregion
    }
}
