using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.PlayerModel.EpisodeModel
{
    public class HotLinks
    {
        [JsonProperty("fhd")] public string? FullHD_m3u8 { get; private set; }

        [JsonProperty("hd")] public string? HD_m3u8 { get; private set; }

        [JsonProperty("sd")] public string? SD_m3u8 { get; private set; }
    }
}
