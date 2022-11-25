using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    /// <summary>
    /// Names configuration. Conteins russian, english and alternative names
    /// </summary>
    public class NamesConfiguration
    {
        /// <summary>
        /// <see cref="Title"/> name in russian
        /// </summary>
        [JsonProperty("ru")] public string? Russian { get; private set; }


        /// <summary>
        /// <see cref="Title"/> name in english
        /// </summary>
        [JsonProperty("en")] public string? English { get; private set; }


        /// <summary>
        /// <see cref="Title"/> alternative name
        /// </summary>
        [JsonProperty("alternative")] public string? Alternative { get; private set; }


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns><see cref="Russian"/> (name in russian)</returns>
        public override string ToString() => Russian;
    }
}
