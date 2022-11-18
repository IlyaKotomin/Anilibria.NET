using Anilibria.NET.Models.Title.PlayerModel;
using Anilibria.NET.Models.Title.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.TorrentsModel.TorrentFileModel
{
    public class TorrentFile
    {
        [JsonProperty("torrent_id")] public int Id { get; set; }

        [JsonProperty("series")] public Series? Series { get; set; }

        [JsonProperty("quality")] public TorrentQuality? Quality { get; set; }

        [JsonProperty("leechers")] public int Leechers { get; set; }

        [JsonProperty("seeders")] public int Seeders { get; set; }

        [JsonProperty("downloads")] public ulong Downloads { get; set; }

        [JsonProperty("total_size")] public ulong Size { get; set; }

        [JsonProperty("url")] public string? RawUrl { get; set; }

        [JsonProperty("uploaded_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? UploadedDate { get; set; }

        [JsonProperty("hash")] public string? Hash { get; set; }

        [JsonProperty("metadata")] public TorrenetMetadate? Metadate { get; set; }

        [JsonProperty("raw_base64_file")] public string? Base64 { get; set; }
    }
}
