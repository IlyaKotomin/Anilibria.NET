using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class TitleTypeConfiguration
    {
        [JsonProperty("full_string")] public string? FullTypeString { get; set; }

        [JsonProperty("code")] public int Code { get; set; }

        [JsonProperty("string")] public string? TypeString { get; set; }

        [JsonProperty("series")] public int Series { get; set; }

        [JsonProperty("length")] public int Length { get; set; }

        public TitleType Type => (TitleType)Code;

        public override string ToString() => FullTypeString;
    }
}
