using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models.Title.PostersModel
{
    public class Posters
    {
        [JsonProperty("small")]
        public Poster Small { get; set; }

        [JsonProperty("medium")]
        public Poster Medium { get; set; }

        [JsonProperty("original")]
        public Poster Original { get; set; }
    }
}
