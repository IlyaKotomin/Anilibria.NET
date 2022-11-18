using Anilibria.NET.Models.Title.PlayerModel;
using Anilibria.NET.Models.Title.TorrentsModel.TorrentFileModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.TorrentsModel
{
    public class Torrent
    {
        [JsonProperty("series")] public Series? Series { get; private set; }

        [JsonProperty("list")] public List<TorrentFile>? Files { get; private set; }
    }
}
