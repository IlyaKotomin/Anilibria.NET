using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.TorrentsModel.TorrentFileModel
{
    /// <summary>
    /// Information about video quality from <see cref="TorrentFile"/>
    /// </summary>
    public class TorrentQuality
    {
        /// <summary>
        /// Full format name as string
        /// </summary>
        [JsonProperty("string")] public string? FullString { get; private set; }


        /// <summary>
        /// Video name fotmat as string
        /// </summary>
        [JsonProperty("type")] public string? VideoFormatString { get; private set; }


        /// <summary>
        /// Video resolution as string
        /// </summary>
        [JsonProperty("resolution")] public string? ResolutionString { get; private set; }


        /// <summary>
        /// Encoder name as string
        /// </summary>
        [JsonProperty("encoder")] public string? EncoderString { get; private set; }

        /// <summary>
        /// Low-quality audio bool
        /// </summary>
        [JsonProperty("lq_audio")] public object? LqAudio { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>Full format name as string</returns>
        public override string ToString() => FullString;
    }
}
