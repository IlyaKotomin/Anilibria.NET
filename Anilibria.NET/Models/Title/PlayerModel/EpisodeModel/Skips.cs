using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel
{
    /// <summary>
    /// Contains information about the beginnings and ends of the opening and ending
    /// </summary>
    public class Skips
    {
        /// <summary>
        /// Opening start and end positions im miliseconds
        /// </summary>
        /// <value>[0] - start of opening, [1] - end of opening</value>
        [JsonProperty("opening")] public List<int>? OpeningTimecodes { get; private set; }


        /// <summary>
        /// Ending start and end positions im miliseconds
        /// </summary>
        /// <value>[0] - start of ending, [1] - end of ending</value>
        [JsonProperty("ending")] public List<int>? EndingTimecodes { get; private set; }


        /// <summary>
        /// Override on .Tostring()
        /// </summary>
        /// <returns><see cref="string"/> in format "<see cref="OpeningTimecodes"/> | <see cref="EndingTimecodes"/>"</returns>
        public override string ToString() => $"{string.Join(", ", OpeningTimecodes!)} | {string.Join(", ", EndingTimecodes!)}";
    }
}
