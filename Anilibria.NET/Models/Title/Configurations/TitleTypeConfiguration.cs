using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    /// <summary>
    /// This class contains the type of the <see cref="Title"/>
    /// as well as the number of episodes in total in the title
    /// and length of episodes
    /// </summary>
    public class TitleTypeConfiguration
    {
        /// <summary>
        /// <see cref="TitleType"/> as string with <see cref="Series"/>
        /// </summary>
        [JsonProperty("full_string")] public string? FullTypeString { get; private set; }


        /// <summary>
        /// <see cref="TitleType"/> as <see cref="int"/>
        /// </summary>
        [JsonProperty("code")] public int? Code { get; private set; }


        /// <summary>
        /// <see cref="TitleType"/> as <see cref="string"/>
        /// </summary>
        [JsonProperty("string")] public string? TypeString { get; private set; }


        /// <summary>
        /// Total number or series
        /// </summary>
        [JsonProperty("series")] public int? Series { get; private set; }


        /// <summary>
        /// Length of episodes as <see cref="string"/> in minutes
        /// </summary>
        [JsonProperty("length")] public int? Length { get; private set; }


        /// <summary>
        /// Type of <see cref="Title"/>
        /// </summary>
        public TitleType Type => (TitleType)Code!;


        /// <summary>
        /// Override on .Tostring()
        /// </summary>
        /// <returns><see cref="FullTypeString"/></returns>
        public override string ToString() => FullTypeString;
    }
}
