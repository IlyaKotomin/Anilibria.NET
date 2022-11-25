using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel
{
    /// <summary>
    /// This class is needed to get short links to .m3u8 files without a host.
    /// Use <see cref="Player.HostLink"/> to build full link to the file
    /// </summary>
    public class HotLinks
    {
        /// <summary>
        /// Link to the FullHD .m3u8 file
        /// </summary>
        /// <value>Link as <see cref="string"/></value>
        [JsonProperty("fhd")] public string? FullHD_m3u8 { get; private set; }


        /// <summary>
        /// Link to the HD .m3u8 file
        /// </summary>
        /// <value>Link as <see cref="string"/></value>
        [JsonProperty("hd")] public string? HD_m3u8 { get; private set; }


        /// <summary>
        /// Link to the SD .m3u8 file
        /// </summary>
        /// <value>Link as <see cref="string"/></value>
        [JsonProperty("sd")] public string? SD_m3u8 { get; private set; }
    }
}
