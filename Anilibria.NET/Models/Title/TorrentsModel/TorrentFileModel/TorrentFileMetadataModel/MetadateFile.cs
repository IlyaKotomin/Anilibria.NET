using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel
{
    public class MetadateFile
    {
        [JsonProperty("file")] public string? FileName { get; private set; }

        [JsonProperty("size")] public ulong FileSize { get; private set; }

        [JsonProperty("offset")] public ulong FileOffset { get; private set; }
    }
}
