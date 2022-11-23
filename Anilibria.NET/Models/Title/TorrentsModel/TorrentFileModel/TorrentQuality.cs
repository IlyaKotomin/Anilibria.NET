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
        [JsonProperty("string")] public string? FullString { get; private set; }

        [JsonProperty("type")] public string? VideoFormat { get; private set; }

        [JsonProperty("resolution")] public string? ResolutionString { get; private set; }

        [JsonProperty("encoder")] public string? EncoderString { get; private set; }

        [JsonProperty("lq_audio")] public object? LqAudio { get; private set; }

        public override string ToString() => FullString;
    }
}
