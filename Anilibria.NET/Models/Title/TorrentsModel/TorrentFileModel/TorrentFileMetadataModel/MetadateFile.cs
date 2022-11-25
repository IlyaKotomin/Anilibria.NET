using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel
{
    /// <summary>
    /// Torrent file metadata, contains information about the file name, size, and offset
    /// </summary>
    public class MetadateFile
    {
        /// <summary>
        /// File name
        /// </summary>
        [JsonProperty("file")] public string? FileName { get; private set; }


        /// <summary>
        /// File size
        /// </summary>
        [JsonProperty("size")] public ulong FileSize { get; private set; }


        /// <summary>
        /// File offset
        /// </summary>
        [JsonProperty("offset")] public ulong FileOffset { get; private set; }
    }
}
