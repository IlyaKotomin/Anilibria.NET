using Newtonsoft.Json;
using Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel;

namespace Anilibria.NET.Models.TitleModel.PlayerModel
{
    /// <summary>
    ///  This class allows you to get a list of <see cref="Episode"/>s of this title, 
    ///  as well as a link to the server where the title is loaded (<see cref="HostLink"/> or <see cref="AlternativePlayerLink"/>), 
    ///  information about its series (<see cref="Series"/>)
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Link to alternative player
        /// </summary>
        [JsonProperty("alternative_player")] public string? AlternativePlayerLink { get; private set; }


        /// <summary>
        /// Link to one of the anilibria`s serves. Use it ti build full link to .m3u8 file
        /// (example: <see cref="HostLink"/> + <see cref="HotLinks.FullHD_m3u8"/>) 
        /// </summary>
        [JsonProperty("host")] public string? HostLink { get; private set; }


        /// <summary>
        /// Information about episodes
        /// </summary>
        [JsonProperty("series")] public Series? Series { get; private set; }


        /// <summary>
        /// List of <see cref="Episode"/>s. Here you can get information about each episode 
        /// </summary>
        [JsonProperty("playlist")] public List<Episode>? Episodes { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns><see cref="HostLink"/></returns>
        public override string ToString() => HostLink;
    }
}
