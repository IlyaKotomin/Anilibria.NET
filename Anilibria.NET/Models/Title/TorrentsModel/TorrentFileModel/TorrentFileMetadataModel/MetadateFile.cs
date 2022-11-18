using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel
{
    public class MetadateFile
    {
        [JsonProperty("file")] public string? FileName { get; set; }

        [JsonProperty("size")] public ulong FileSize { get; set; }

        [JsonProperty("offset")] public ulong FileOffset { get; set; }
    }
}
