using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel
{
    /// <summary>
    /// This class contains information about the episode number (<see cref="Number"/>),
    /// a preview message from the voiceover team (<see cref="Preview"/>),
    /// values for opening and ending skips (<see cref="Skips"/>),
    /// links to .m3y8 files (<see cref="HotLinks"/>),
    /// and the release time of the title (<see cref="CreatedDate"/>).
    /// </summary>
    public class Episode
    {
        /// <summary>
        /// Episode number in <see cref="Title"/>
        /// </summary>
        [JsonProperty("serie")] public string? Number { get; private set; }


        /// <summary>
        /// Message from voiceover team
        /// </summary>
        [JsonProperty("preview")] public string? Preview { get; private set; }


        /// <summary>
        /// Information about skips in episode
        /// </summary>
        [JsonProperty("skips")] public Skips? Skips { get; private set; }


        /// <summary>
        /// Hot links to .m3u8 files without host link (short version)
        /// </summary>
        [JsonProperty("hls")] public HotLinks? HotLinks { get; private set; }


        /// <summary>
        /// Release date of episode
        /// </summary>
        [JsonProperty("created_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Override of .ToString()
        /// </summary>
        /// <returns>Serie <see cref="Number"/> as <see cref=" string"/></returns>
        public override string ToString() => $"Serie {Number}";
    }
}
