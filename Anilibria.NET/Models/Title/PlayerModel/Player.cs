using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.PlayerModel
{
    public class Player
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("alternative_player")]
        public string AlternativePlayerLink { get; set; }

        [JsonProperty("host")]
        public string? HostLink { get; set; }

        [JsonProperty("series")]
        public Series Series { get; set; }

        [JsonProperty("playlist")]
        public List<Playlist> Episodes { get; set; }
    }
}
