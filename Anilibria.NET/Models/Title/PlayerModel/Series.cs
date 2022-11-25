using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.PlayerModel
{
    /// <summary>
    /// Class containing information about the series of the title
    /// </summary>
    public class Series
    {
        /// <summary>
        /// From what series is available for watch
        /// </summary>
        [JsonProperty("first")]
        public int First { get; private set; }

        /// <summary>
        /// Latest episode available for viewing
        /// </summary>
        [JsonProperty("last")]
        public int Last { get; private set; }


        /// <summary>
        /// Formated string in format First-Last (example: 1-24)
        /// </summary>
        [JsonProperty("string")]
        public string? String { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns><see cref="String"/></returns>
        public override string ToString() => String;
    }
}
