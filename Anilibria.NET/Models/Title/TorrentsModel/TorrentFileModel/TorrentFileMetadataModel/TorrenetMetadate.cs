using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel.TorrentFileMetadataModel
{
    public class TorrenetMetadate
    {
        [JsonProperty("hash")] public string? Hash { get; private set; }

        [JsonProperty("name")] public string? Name { get; private set; }

        [JsonProperty("announce")] public string[]? Announce { get; private set; }

        [JsonProperty("files_list")] public List<MetadateFile>? MetadateFiles { get; private set; }

        [JsonProperty("created_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime CreatedDate { get; private set; }
    }
}
