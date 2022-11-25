using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models
{
    /// <summary>
    /// Post in YouTube from Anilibria
    /// </summary>
    public class YouTubePost
    {
        /// <summary>
        /// ID of post
        /// </summary>
        [JsonProperty("id")] public int? Id { get; private set; }


        /// <summary>
        /// Name of post
        /// </summary>
        [JsonProperty("title")] public string? Name { get; private set; }


        /// <summary>
        /// Url to img on youtube images
        /// </summary>
        [JsonProperty("image")] public string? ImageUrl { get; private set; }


        /// <summary>
        /// Count of comment on post
        /// </summary>
        [JsonProperty("comments")] public int? Comments { get; private set; }


        /// <summary>
        /// Views on post
        /// </summary>
        [JsonProperty("views")] public int? Views { get; private set; }
        

        /// <summary>
        /// Id on youtube.com
        /// </summary>
        [JsonProperty("youtube_id")] public string? YoutubeId { get; private set; }


        /// <summary>
        /// Post creation date
        /// </summary>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime Release { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>Name of post</returns>
        public override string ToString() => Name;
    }
}
