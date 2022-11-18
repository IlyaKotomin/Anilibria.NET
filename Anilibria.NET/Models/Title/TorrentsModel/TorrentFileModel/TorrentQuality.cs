using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel
{
    public class TorrentQuality
    {
        [JsonProperty("string")] public string? FullString { get; set; }

        [JsonProperty("type")] public string? VideoFormat { get; set; }

        [JsonProperty("resolution")] public string? ResolutionString { get; set; }

        [JsonProperty("encoder")] public string? EncoderString { get; set; }

        [JsonProperty("lq_audio")] public object? LqAudio { get; set; }

        public override string ToString() => FullString;
    }
}
