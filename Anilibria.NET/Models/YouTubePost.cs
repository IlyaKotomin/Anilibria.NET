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
        [JsonProperty("id")] public int? Id { get; set; }

        [JsonProperty("title")] public string? Name { get; set; }

        [JsonProperty("image")] public string? ImageUrl { get; set; }

        [JsonProperty("comments")] public int? Comments { get; set; }

        [JsonProperty("views")] public int? Views { get; set; }
        
        [JsonProperty("youtube_id")] public string? YoutubeId { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime Release { get; set; }

        public override string ToString() => Name;
    }
}
