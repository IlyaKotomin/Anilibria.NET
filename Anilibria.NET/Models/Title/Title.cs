using Anilibria.NET.Models.Title.PlayerModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class Title
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("names")]
        public Names Names { get; set; }

        [JsonProperty("announce")]
        public string Announce { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("updated")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime UdatedDate { get; set; }

        [JsonProperty("last_change")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime LastChangeDate { get; set; }

        [JsonProperty("type")]
        public TitleType TitleType { get; set; }

        [JsonProperty("genres")]
        public List<string> Genres { get; set; }

        [JsonProperty("team")]
        public Team Team { get; set; }

        [JsonProperty("season")]
        public Season Season { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("in_favorites")]
        public string InFavorites { get; set; }

        [JsonProperty("blocked")]
        public Blocked Blocked { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }
    }
}
