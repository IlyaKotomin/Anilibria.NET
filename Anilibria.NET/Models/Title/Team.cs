using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class Team
    {
        [JsonProperty("voice")] public List<string>? Voice { get; set; }

        [JsonProperty("translator")] public List<string>? Translator { get; set; }

        [JsonProperty("editing")] public List<string>? Editing { get; set; }

        [JsonProperty("decor")] public List<string>? Decor { get; set; }

        [JsonProperty("timing")] public List<string>? Timing { get; set; }

        public int Count => Voice!.Count + Translator!.Count + Editing!.Count + Decor!.Count + Timing!.Count;
    }
}
