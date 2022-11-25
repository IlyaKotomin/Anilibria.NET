using Anilibria.NET.Models.TitleModel;

namespace Anilibria.NET.Builders
{
    /// <summary>
    /// Query builder class. Use it to search titles at
    /// <see cref="Anilibria.NET.Client.AnilibriaAPI.SearchTitlesAsync(SearchQueryBuilder)"/>.
    /// You get search by voiceover team, text, ganres, seasons and years
    /// </summary>
    public class SearchQueryBuilder
    {
        #region Public fields


        /// <summary>
        /// Titels limit in query
        /// </summary>
        public int LimitIndex;


        /// <summary>
        /// Search titels after this index
        /// </summary>
        public int AfterIndex;


        #endregion


        #region Private fields


        /// <summary>
        /// Full query string
        /// </summary>
        private string _query = "";


        /// <summary>
        /// All search keys
        /// </summary>
        private Dictionary<string, string> _searchKeys = new Dictionary<string, string>();


        #endregion


        /// <summary>
        /// Creating of seach builder
        /// </summary>
        /// <param name="limit">Limit of Titles in response</param>
        /// <param name="after">Response tiltes after that index</param>
        public SearchQueryBuilder(int limit, int after)
        {
            LimitIndex = limit;
            AfterIndex = after;
        }


        #region Public Methods

        /// <summary>
        /// Adds text to search
        /// </summary>
        /// <param name="text">text to search key</param>
        public void SearchByText(string text) =>
            SearchByKey("search", text);


        /// <summary>
        /// Adds years to search
        /// </summary>
        /// <param name="years">Years to search key</param>
        public void SearchByYear(int[] years) =>
            SearchByKey("year", string.Join(',', years));

        /// <summary>
        /// Adds year to search
        /// </summary>
        /// <param name="year">Year to search key</param>
        public void SearchByYear(int year) =>
            SearchByKey("year", year);


        /// <summary>
        /// Adds seasons to search
        /// </summary>
        /// <param name="seasons">Seasons to search key</param>
        public void SearchBySeasons(Season[] seasons)
        {
            int[] ints = Array.ConvertAll(seasons, value => (int)value);
            SearchByKey("season_code", string.Join(',', ints));
        }


        /// <summary>
        /// Adds genres to search
        /// </summary>
        /// <param name="genres">Genres to search</param>
        public void SearchByGenres(string[] genres) =>
                SearchByKey("genres", string.Join(',', genres));


        /// <summary>
        /// Adds voicers to search
        /// </summary>
        /// <param name="voicers">Voicers to search keys</param>
        public void SearchByVoicers(string[] voicers) =>
                SearchByKey("voice", string.Join(',', voicers));


        /// <summary>
        /// Adds translators to search
        /// </summary>
        /// <param name="translators">Translators to search</param>
        public void SearchByTranslators(string[] translators) =>
                SearchByKey("translators", string.Join(',', translators));


        /// <summary>
        /// Adds editors to search
        /// </summary>
        /// <param name="editors">Editors to search</param>
        public void SearchByEditors(string[] editors) =>
                SearchByKey("editing", string.Join(',', editors));


        /// <summary>
        /// Adds decors to search
        /// </summary>
        /// <param name="decors">Decors to search</param>
        public void SearchByDecors(string[] decors) =>
                SearchByKey("decor", string.Join(',', decors));


        /// <summary>
        /// Adds timings to search
        /// </summary>
        /// <param name="timings">Timings to search</param>
        public void SearchByTimings(string[] timings) =>
                SearchByKey("timings", string.Join(',', timings));


        /// <summary>
        /// Returns full search request as <see cref="string"/>
        /// </summary>
        /// <returns><see cref="string"/> - full search request</returns>
        internal string Build()
        {
            _query = $"/searchTitles?after={AfterIndex}&limit={LimitIndex}";

            foreach (var keyValuePair in _searchKeys)
                _query += $"&{keyValuePair.Key}={keyValuePair.Value}";

            _query = _query.Replace(" ", "%20");

            return _query + "&remove=player,torrents,posters";
        }


        #endregion


        #region Private methods
        
        
        private void SearchByKey(string key, object value)
        {
            if (_searchKeys.ContainsKey(key))
                _searchKeys[key] = string.Join(',', value);
            else
                _searchKeys.Add(key, string.Join(',', value));
        }


        #endregion
    }
}
