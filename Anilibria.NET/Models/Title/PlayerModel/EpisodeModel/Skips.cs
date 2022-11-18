using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.PlayerModel.EpisodeModel
{
    public class Skips
    {
        [JsonProperty("opening")]
        public List<int> OpeningTimecodes { get; set; }

        [JsonProperty("ending")]
        public List<int> EndingTimecodes { get; set; }
    }
}
