using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel
{
    public class Skips
    {
        [JsonProperty("opening")] public List<int>? OpeningTimecodes { get; private set; }

        [JsonProperty("ending")] public List<int>? EndingTimecodes { get; private set; }

        public override string ToString() => $"{string.Join(", ", OpeningTimecodes!)} | {string.Join(", ", EndingTimecodes!)}";
    }
}
