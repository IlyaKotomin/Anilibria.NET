using Anilibria.NET.Models.TitleModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Anilibria.NET.Builders
{
    public class SearchQueryBuilder
    {
        public int LimitIndex;
        public int AfterIndex;

        private string _query = "";
        private Dictionary<string, string> _searchKeys = new Dictionary<string, string>();

        public SearchQueryBuilder(int limit, int after)
        {
            LimitIndex = limit;
            AfterIndex = after;
        }


        public void SearchByText(string text) =>
            SearchByKey("search", text);

        public void SearchByYear(int[] years) =>
            SearchByKey("year", string.Join(',', years));

        public void SearchByYear(int year) =>
            SearchByKey("year", year);

        public void SearchBySeason(Season[] seasons)
        {
            int[] ints = Array.ConvertAll(seasons, value => (int)value);
            SearchByKey("season_code", string.Join(',', ints));
        }

        public void SearchByGenres(string[] genres) =>
                SearchByKey("genres", string.Join(',', genres));

        public void SearchByVoicers(string[] voicers) =>
                SearchByKey("voice", string.Join(',', voicers));

        public void SearchByTranslators(string[] translator) =>
                SearchByKey("translator", string.Join(',', translator));

        public void SearchByEditors(string[] editors) =>
                SearchByKey("editing", string.Join(',', editors));

        public void SearchByDecors(string[] decors) =>
                SearchByKey("decor", string.Join(',', decors));

        public void SearchByTiming(string[] timing) =>
                SearchByKey("timing", string.Join(',', timing));

        public string Build()
        {
            _query = $"/searchTitles?after={AfterIndex}&limit={LimitIndex}";

            foreach (var keyValuePair in _searchKeys)
                _query += $"&{keyValuePair.Key}={keyValuePair.Value}";

            _query = _query.Replace(" ", "%20");

            return _query + "&remove=player,torrents,posters";
        }


        private void SearchByKey(string key, object value)
        {
            if (_searchKeys.ContainsKey(key))
                _searchKeys[key] = string.Join(',', value);
            else
                _searchKeys.Add(key, string.Join(',', value));
        }
    }
}
