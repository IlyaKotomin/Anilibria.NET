using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models
{
    public class YouTubePost
    {
        [JsonProperty("id")] public int? Id { get; private set; }

        [JsonProperty("title")] public string? Name { get; private set; }

        [JsonProperty("image")] public string? ImageUrl { get; private set; }

        [JsonProperty("comments")] public int? Comments { get; private set; }

        [JsonProperty("views")] public int? Views { get; private set; }
        
        [JsonProperty("youtube_id")] public string? YoutubeId { get; private set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime Release { get; private set; }

        public override string ToString() => Name;
    }
}
