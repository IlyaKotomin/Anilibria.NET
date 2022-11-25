using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel
{
    /// <summary>
    /// The team that worked on the title
    /// </summary>
    public class Team
    {
        /// <summary>
        /// People who voiced the title
        /// </summary>
        [JsonProperty("voice")] public List<string>? Voicers { get; private set; }


        /// <summary>
        /// People who translated the title
        /// </summary>
        [JsonProperty("translator")] public List<string>? Translators { get; private set; }


        /// <summary>
        /// People who etid the title
        /// </summary>
        [JsonProperty("editing")] public List<string>? Editors { get; private set; }


        /// <summary>
        /// People who decor the title
        /// </summary>
        [JsonProperty("decor")] public List<string>? Decors { get; private set; }


        /// <summary>
        /// People who made timings for the title
        /// </summary>
        [JsonProperty("timing")] public List<string>? Timings { get; private set; }


        /// <summary>
        /// Team members count
        /// </summary>
        public int Count => Voicers!.Count + Translators!.Count + Editors!.Count + Decors!.Count + Timings!.Count;
    }
}
