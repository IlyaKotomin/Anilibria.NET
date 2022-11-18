using Newtonsoft.Json;
using Anilibria.NET.Models.Title.PlayerModel.EpisodeModel;

namespace Anilibria.NET.Models.Title.PlayerModel
{
    public class Player
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("alternative_player")]
        public string? AlternativePlayerLink { get; set; }

        [JsonProperty("host")]
        public string? HostLink { get; set; }

        [JsonProperty("series")]
        public Series? Series { get; set; }

        [JsonProperty("playlist")]
        public List<Episode>? Episodes { get; set; }
    }
}
