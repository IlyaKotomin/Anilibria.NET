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
        public int First { get; private set; }

        [JsonProperty("last")]
        public int Last { get; private set; }

        [JsonProperty("string")]
        public string? String { get; private set; }
        public override string ToString() => String;
    }
}
