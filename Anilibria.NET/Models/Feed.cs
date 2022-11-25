using Anilibria.NET.Models.TitleModel;
using Newtonsoft.Json;

namespace Anilibria.NET.Models
{
    /// <summary>
    /// Website news feed
    /// </summary>
    public class Feed
    {
        /// <summary>
        /// Youtube post from feed
        /// </summary>
        [JsonProperty("youtube")] public YouTubePost? YouTubePost { get; private set; }


        /// <summary>
        /// Title from feed
        /// </summary>
        [JsonProperty("Title")] public Title? Title { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>YouTube post name or Title name in russian</returns>
        public override string ToString() => YouTubePost == null ? Title!.NamesConfiguration!.Russian : YouTubePost.Name;
    }
}
