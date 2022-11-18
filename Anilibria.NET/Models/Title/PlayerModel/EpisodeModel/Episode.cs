using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.PlayerModel.EpisodeModel
{
    public class Episode
    {
        [JsonProperty("serie")] public string? Number { get; set; }

        [JsonProperty("preview")] public string? Preview { get; set; }

        [JsonProperty("skips")] public Skips? Skips { get; set; }

        [JsonProperty("hls")] public HotLinks? HotLinks { get; set; }
        
        [JsonProperty("created_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime CreatedDate { get; set; }
    }
}
