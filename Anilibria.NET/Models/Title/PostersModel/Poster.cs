using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.PostersModel
{
    /// <summary>
    /// Class containing a short link to the poster without a link to the site, a raw base64 poster string and an image converted from a raw base64 string
    /// </summary>
    public class Poster
    {
        /// <summary>
        /// Link to the poster without a link to the site
        /// </summary>
        [JsonProperty("url")] public string? Url { get; private set; }


        /// <summary>
        /// Raw base64 string of poster. Convert it to get image as <see cref="byte"/> array
        /// </summary>
        [JsonProperty("raw_base64_file")] public string? Base64 { get; private set; }


        /// <summary>
        /// Image as <see cref="byte"/> array
        /// </summary>
        public byte[] Image => Convert.FromBase64String(Base64!);


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>Short poster image url</returns>
        public override string ToString() => Url;
    }
}
