using Anilibria.NET.Models.TitleModel.PlayerModel;
using Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel;
using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel
{
    public class Torrent
    {
        /// <summary>
        /// Series in torrnet files
        /// </summary>
        [JsonProperty("series")] public Series? Series { get; private set; }


        /// <summary>
        /// List of torrent files
        /// </summary>
        [JsonProperty("list")] public List<TorrentFile>? Files { get; private set; }
    }
}
