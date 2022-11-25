using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    /// <summary>
    /// Status configuration of <see cref="Title"/>
    /// </summary>
    public class StatusConfiguration
    {
        /// <summary>
        /// <see cref="TitleStatus"/> as <see cref="string"/> in russian
        /// </summary>
        [JsonProperty("string")] public string? String { get; private set; }


        /// <summary>
        /// <see cref="TitleStatus"/> as <see cref="int"/>
        /// </summary>
        [JsonProperty("code")] public int Code { get; private set; }


        /// <summary>
        /// <see cref="Title"/> status
        /// </summary>
        public TitleStatus Status => (TitleStatus)Code;


        /// <summary>
        /// Overrride on .ToString()
        /// </summary>
        /// <returns><see cref="TitleStatus"/> as <see cref="String"/></returns>
        public override string ToString() => String;
    }
}
