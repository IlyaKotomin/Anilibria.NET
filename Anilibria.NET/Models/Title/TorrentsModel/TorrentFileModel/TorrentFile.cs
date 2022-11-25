using Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel;
using Anilibria.NET.Models.TitleModel.PlayerModel;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel
{
    /// <summary>
    /// Torrent file info and data class, u can get raw base64 string of torrent file and see file metadata 
    /// </summary>
    public class TorrentFile
    {
        /// <summary>
        /// Torrent id in anilibria.tv
        /// </summary>
        [JsonProperty("torrent_id")] public int Id { get; private set; }


        /// <summary>
        /// Information about series of <see cref="Title"/>
        /// </summary>
        [JsonProperty("series")] public Series? Series { get; private set; }


        /// <summary>
        /// Torrent and video quality information
        /// </summary>
        [JsonProperty("quality")] public TorrentQuality? Quality { get; private set; }


        /// <summary>
        /// Leechers count of cerrent torrent file
        /// </summary>
        [JsonProperty("leechers")] public int Leechers { get; private set; }


        /// <summary>
        /// Seeders count of currrent torrent file
        /// </summary>
        [JsonProperty("seeders")] public int Seeders { get; private set; }


        /// <summary>
        /// Downloads count of current torrent file
        /// </summary>
        [JsonProperty("downloads")] public ulong Downloads { get; private set; }


        /// <summary>
        /// Size in <see cref="byte"/>s of current torrent file
        /// </summary>
        [JsonProperty("total_size")] public ulong Size { get; private set; }


        /// <summary>
        /// Raw url to torrent file
        /// </summary>
        [JsonProperty("url")] public string? RawUrl { get; private set; }



        /// <summary>
        /// Date of uploading the torrent file to the site
        /// </summary>
        [JsonProperty("uploaded_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime? UploadedDate { get; private set; }


        /// <summary>
        /// Current torrent file hash
        /// </summary>
        [JsonProperty("hash")] public string? Hash { get; private set; }


        /// <summary>
        /// Current torrent file metadate (<see cref="TorrenetMetadate"/>)
        /// </summary>
        [JsonProperty("metadata")] public TorrenetMetadate? Metadate { get; private set; }


        /// <summary>
        /// Raw base64 string of torrent file. You can convert it to get .torrent file
        /// </summary>
        [JsonProperty("raw_base64_file")] public string? Base64 { get; private set; }
    }
}
