using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class Blocked
    {
        [JsonProperty("blocked")]
        public bool IsBlocked { get; set; }
        
        [JsonProperty("bakanim")]
        public bool IsBakanim { get; set; }
    }
}
