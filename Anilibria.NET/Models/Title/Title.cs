using Anilibria.NET.Models.Title.PlayerModel;
using Anilibria.NET.Models.Title.PostersModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models.Title
{
    public class Title
    {
        #region Common Info

        [JsonProperty("id")] public int Id { get; set; }

        [JsonProperty("code")] public string? Code { get; set; }

        [JsonProperty("names")] public Names? Names { get; set; }
        
        [JsonProperty("announce")] public string? Announce { get; set; }

        [JsonProperty("genres")] public List<string>? Genres { get; set; }
        
        [JsonProperty("description")] public string? Description { get; set; }


        #endregion


        #region Detail Info
        [JsonProperty("type")] public TitleType? TitleType { get; set; }
        
        [JsonProperty("status")] public Status? Status { get; set; }
        
        [JsonProperty("team")] public Team? Team { get; set; }

        [JsonProperty("season")] public Season? Season { get; set; }

        [JsonProperty("in_favorites")] public string? InFavorites { get; set; }

        [JsonProperty("blocked")] public Blocked? Blocked { get; set; }

        #endregion


        #region Content
        [JsonProperty("player")] public Player? Player { get; set; }

        [JsonProperty("posters")] public Posters? Posters { get; set; }

        #endregion


        #region Dates

        [JsonProperty("updated")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime UdatedDate { get; set; }

        [JsonProperty("last_change")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime LastChangeDate { get; set; }

        #endregion


        #region Methods

        public override string ToString() => Code;

        #endregion
    }
}
