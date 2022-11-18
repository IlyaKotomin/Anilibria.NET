using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel
{
    public class Team
    {
        [JsonProperty("voice")] public List<string>? Voice { get; private set; }

        [JsonProperty("translator")] public List<string>? Translator { get; private set; }

        [JsonProperty("editing")] public List<string>? Editing { get; private set; }

        [JsonProperty("decor")] public List<string>? Decor { get; private set; }

        [JsonProperty("timing")] public List<string>? Timing { get; private set; }

        public int Count => Voice!.Count + Translator!.Count + Editing!.Count + Decor!.Count + Timing!.Count;
    }
}
