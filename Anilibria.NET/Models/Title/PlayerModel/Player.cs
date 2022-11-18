using Newtonsoft.Json;
using Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel;

namespace Anilibria.NET.Models.TitleModel.PlayerModel
{
    public class Player
    {
        [JsonProperty("alternative_player")] public string? AlternativePlayerLink { get; private set; }

        [JsonProperty("host")] public string? HostLink { get; private set; }

        [JsonProperty("series")] public Series? Series { get; private set; }

        [JsonProperty("playlist")] public List<Episode>? Playlist { get; private set; }

        public override string ToString() => HostLink;
    }
}
