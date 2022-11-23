using Anilibria.NET.Client;
using Anilibria.NET.Helpers;
using Anilibria.NET.Models.TitleModel.Configurations;
using Anilibria.NET.Models.TitleModel.PlayerModel;
using Anilibria.NET.Models.TitleModel.PostersModel;
using Anilibria.NET.Models.TitleModel.TorrentsModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models.TitleModel
{
    public class Title
    {
        #region Common-Info

        [JsonProperty("team")] public Team? Team { get; private set; }

        [JsonProperty("in_favorites")] public string? InFavorites { get; private set; }

        public string Name => NamesConfiguration!.Russian;

        public bool BlockedInRussia => BlockedConfiguration!.IsBlockedInRussia;

        #endregion


        #region Detail Info

        [JsonProperty("id")] public int Id { get; private set; }

        [JsonProperty("code")] public string? Code { get; private set; }

        [JsonProperty("announce")] public string? Announce { get; private set; }

        [JsonProperty("genres")] public List<string>? Genres { get; private set; }
        
        [JsonProperty("description")] public string? Description { get; private set; }

        public TitleType TitleType => TitleTypeConfiguration!.Type;

        public TitleStatus TitleStatus => StatusConfiguration!.Status;

        public Season Season => SeasonConfiguration!.Season;

        #endregion


        #region Configurations

        [JsonProperty("type")] public TitleTypeConfiguration? TitleTypeConfiguration { get; private set; }

        [JsonProperty("status")] public StatusConfiguration? StatusConfiguration { get; private set; }
        
        [JsonProperty("season")] public SeasonConfiguration? SeasonConfiguration { get; private set; }

        [JsonProperty("names")] public NamesConfiguration? NamesConfiguration { get; private set; }
        
        [JsonProperty("blocked")] public BlockedConfiguration? BlockedConfiguration { get; private set; }

        #endregion


        #region Content

        public async Task<Player> GetPlayerAsync() =>
            await Utilities.GetSubClassData<Player>("player", Urls.GetTitlePlayerUri(Code!).AbsoluteUri, AnilibriaAPI.HttpClient);


        public async Task<Posters> GetPostersAsync(bool downloadBase64) =>
             await Utilities.GetSubClassData<Posters>("posters",
                                                      Urls.GetTitlePostersUri(Code!).AbsoluteUri
                                                      + (downloadBase64 ? "&include=raw_poster" : ""),
                                                      AnilibriaAPI.HttpClient);


        public async Task<Torrent> GetTorrentAsync(bool downloadMetadate, bool downloadBase64)
        {
            string[] includes = new string[2];

            if (downloadMetadate)
                includes[0] = "torrent_meta";

            if (downloadBase64)
                includes[1] = "raw_torrent";

            string rootUrl = Urls.GetTitleTorrentUri(Id).AbsoluteUri + "&include=" + string.Join(',', includes);

            return await Utilities.GetSubClassData<Torrent>("torrents", rootUrl, AnilibriaAPI.HttpClient);
        }

        #endregion


        #region Dates

        [JsonProperty("updated")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? UdatedDate { get; private set; }

        [JsonProperty("last_change")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? LastChangeDate { get; private set; }

        #endregion


        #region Methods

        public override string ToString() => Code;

        #endregion
    }
}
