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
            new Uri($"{API_ROOT_URL}/getTitle?code={code}&remove=player,torrents,posters");

        internal static Uri GetTitlesUri(int[] id) =>
            new Uri($"{API_ROOT_URL}/getTitles?id={string.Join(",", id)}&remove=player,torrents,posters");

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

        #endregion
    }
}
