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
    /// <summary>
    /// Translated title from anilibtia.tv!
    /// You can get all information about the title,
    /// like: names, posters, episodes, torrent files ect.
    /// Reed docs to see more
    /// </summary>
    public class Title
    {
        #region Common-Info


        /// <summary>
        /// The team that worked on the title
        /// </summary>
        [JsonProperty("team")] public Team? Team { get; private set; }


        /// <summary>
        /// The number of users who added the title to favorites
        /// </summary>
        [JsonProperty("in_favorites")] public string? InFavorites { get; private set; }


        /// <summary>
        /// Name of title in russian
        /// </summary>
        public string Name => NamesConfiguration!.Russian;


        /// <summary>
        /// State of title blocking in russia
        /// </summary>
        public bool IsBlockedInRussia => BlockedConfiguration!.IsBlockedInRussia;


        #endregion


        #region Detail Info


        /// <summary>
        /// Title ID
        /// </summary>
        [JsonProperty("id")] public int Id { get; private set; }


        /// <summary>
        /// Title code, used to create a link
        /// </summary>
        [JsonProperty("code")] public string? Code { get; private set; }


        /// <summary>
        /// Message from anilibira team for this title
        /// </summary>
        [JsonProperty("announce")] public string? Announce { get; private set; }


        /// <summary>
        /// List of genres
        /// </summary>
        [JsonProperty("genres")] public List<string>? Genres { get; private set; }


        /// <summary>
        /// Title description
        /// </summary>
        [JsonProperty("description")] public string? Description { get; private set; }


        /// <summary>
        /// Type of title
        /// </summary>
        public TitleType Type => TitleTypeConfiguration!.Type;


        /// <summary>
        /// Title status
        /// </summary>
        public TitleStatus Status => StatusConfiguration!.Status;


        /// <summary>
        /// Title season
        /// </summary>
        public Season Season => SeasonConfiguration!.Season;


        #endregion


        #region Configurations


        /// <summary>
        /// Configuration of title type
        /// </summary>
        [JsonProperty("type")] public TitleTypeConfiguration? TitleTypeConfiguration { get; private set; }


        /// <summary>
        /// Configuration of title status
        /// </summary>
        [JsonProperty("status")] public StatusConfiguration? StatusConfiguration { get; private set; }


        /// <summary>
        /// Configuration of title season
        /// </summary>
        [JsonProperty("season")] public SeasonConfiguration? SeasonConfiguration { get; private set; }


        /// <summary>
        /// Configuration of title name in different languages
        /// </summary>
        [JsonProperty("names")] public NamesConfiguration? NamesConfiguration { get; private set; }
        

        /// <summary>
        /// Blocking state configuration of title
        /// </summary>
        [JsonProperty("blocked")] public BlockedConfiguration? BlockedConfiguration { get; private set; }

        #endregion


        #region Content


        /// <summary>
        /// Getting the title player
        /// </summary>
        /// <returns>Player of title</returns>
        public async Task<Player> GetPlayerAsync() =>
            await Utilities.GetSubClassData<Player>("player", Urls.GetTitlePlayerUri(Code!).AbsoluteUri, AnilibriaAPI.HttpClient);


        /// <summary>
        /// Getting title posters
        /// </summary>
        /// <param name="downloadBase64">if true, posters will be downloaded with raw base64 image</param>
        /// <returns></returns>
        public async Task<Posters> GetPostersAsync(bool downloadBase64) =>
             await Utilities.GetSubClassData<Posters>("posters",
                                                      Urls.GetTitlePostersUri(Code!).AbsoluteUri
                                                      + (downloadBase64 ? "&include=raw_poster" : ""),
                                                      AnilibriaAPI.HttpClient);


        /// <summary>
        /// Getting the title torrent files
        /// </summary>
        /// <param name="downloadMetadate">if true: download metadata of files</param>
        /// <param name="downloadBase64">if true: download raw base64 torrent files</param>
        /// <returns></returns>
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


        /// <summary>
        /// Last update date
        /// </summary>
        [JsonProperty("updated")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? UdatedDate { get; private set; }



        /// <summary>
        /// Last change date
        /// </summary>

        [JsonProperty("last_change")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? LastChangeDate { get; private set; }

        #endregion


        #region Methods


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>Title code</returns>
        public override string ToString() => Code;

        #endregion
    }
}
