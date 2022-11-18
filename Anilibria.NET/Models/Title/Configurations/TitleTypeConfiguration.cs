using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    public class TitleTypeConfiguration
    {
        [JsonProperty("full_string")] public string? FullTypeString { get; private set; }

        [JsonProperty("code")] public int? Code { get; private set; }

        [JsonProperty("string")] public string? TypeString { get; private set; }

        [JsonProperty("series")] public int? Series { get; private set; }

        [JsonProperty("length")] public int? Length { get; private set; }

        public TitleType Type => (TitleType)Code!;

        public override string ToString() => FullTypeString;
    }
}
