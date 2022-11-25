using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel
{
    /// <summary>
    /// Torrent metadete configuration
    /// </summary>
    public class TorrenetMetadate
    {
        /// <summary>
        /// Torrent file hash string
        /// </summary>
        [JsonProperty("hash")] public string? Hash { get; private set; }


        /// <summary>
        /// Torrent file name
        /// </summary>
        [JsonProperty("name")] public string? Name { get; private set; }


        /// <summary>
        /// An array of strings containing a list of trackers
        /// </summary>
        [JsonProperty("announce")] public string[]? Announce { get; private set; }

        /// <summary>
        /// An array of <see cref="MetadateFile"/>s containing a list of files in the torrent
        /// </summary>
        [JsonProperty("files_list")] public List<MetadateFile>? MetadateFiles { get; private set; }



        /// <summary>
        /// Torrent creation time
        /// </summary>
        [JsonProperty("created_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime CreatedDate { get; private set; }
    }
}
