using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models
{
    public class Feed
    {
        [JsonProperty("youtube")] public YouTubePost? YouTubePost { get; set; }

        [JsonProperty("Title")] public Title? Title { get; set; }

        public override string ToString() => YouTubePost == null ? Title!.NamesConfiguration!.Russian : YouTubePost.Name;
    }
}
