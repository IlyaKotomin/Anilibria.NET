using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.Configurations
{
    public class BlockedConfiguration
    {
        [JsonProperty("blocked")] public bool IsBlockedInRussia { get; private set; }

        [JsonProperty("bakanim")] public bool IsBakanimByWakanim { get; private set; }

        public override string ToString() => IsBlockedInRussia.ToString();
    }
}
