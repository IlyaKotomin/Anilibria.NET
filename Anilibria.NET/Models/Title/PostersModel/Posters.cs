using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.PostersModel
{
    /// <summary>
    /// Class containing small, medium and original <see cref="Poster"/>s for the title
    /// </summary>
    public class Posters
    {
        /// <summary>
        /// Small size poster
        /// </summary>
        [JsonProperty("small")] public Poster? Small { get; private set; }

        /// <summary>
        /// Medium size poster
        /// </summary>
        [JsonProperty("medium")] public Poster? Medium { get; private set; }

        /// <summary>
        /// Original size poster
        /// </summary>
        [JsonProperty("original")] public Poster? Original { get; private set; }
    }
}
