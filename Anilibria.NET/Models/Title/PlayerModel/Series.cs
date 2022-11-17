using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.PlayerModel
{
    public class Series
    {
        [JsonProperty("first")]
        public int First { get; set; }

        [JsonProperty("last")]
        public int Last { get; set; }

        [JsonProperty("string")]
        public string? String { get; set; }
        public override string ToString() => String;
    }
}
