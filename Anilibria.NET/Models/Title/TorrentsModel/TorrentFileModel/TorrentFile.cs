using Anilibria.NET.Models.TitleModel.PlayerModel;
using Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel
{
    public class TorrentFile
    {
        [JsonProperty("torrent_id")] public int Id { get; private set; }

        [JsonProperty("series")] public Series? Series { get; private set; }

        [JsonProperty("quality")] public TorrentQuality? Quality { get; private set; }

        [JsonProperty("leechers")] public int Leechers { get; private set; }

        [JsonProperty("seeders")] public int Seeders { get; private set; }

        [JsonProperty("downloads")] public ulong Downloads { get; private set; }

        [JsonProperty("total_size")] public ulong Size { get; private set; }

        [JsonProperty("url")] public string? RawUrl { get; private set; }

        [JsonProperty("uploaded_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? UploadedDate { get; private set; }

        [JsonProperty("hash")] public string? Hash { get; private set; }

        [JsonProperty("metadata")] public TorrenetMetadate? Metadate { get; private set; }

        [JsonProperty("raw_base64_file")] public string? Base64 { get; private set; }
    }
}
