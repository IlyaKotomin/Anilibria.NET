using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models.TitleModel.PostersModel
{
    public class Posters
    {
        [JsonProperty("small")] public Poster? Small { get; private set; }

        [JsonProperty("medium")] public Poster? Medium { get; private set; }

        [JsonProperty("original")] public Poster? Original { get; private set; }
    }
}
