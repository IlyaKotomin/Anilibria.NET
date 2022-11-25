using Newtonsoft.Json;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    /// <summary>
    /// Configuration of season
    /// </summary>
    public class SeasonConfiguration
    {
        /// <summary>
        /// <see cref="TitleModel.Season"/> as <see cref="String"/> in russian
        /// </summary>
        [JsonProperty("string")] public string? String { get; private set; }


        /// <summary>
        /// <see cref="TitleModel.Season"/> as <see cref="int"/>
        /// </summary>
        [JsonProperty("code")] public int? Code { get; private set; }


        /// <summary>
        /// Year of title release day
        /// </summary>
        [JsonProperty("year")] public int? Year { get; private set; }


        /// <summary>
        /// Number of the day on which the title was released
        /// </summary>
        [JsonProperty("week_day")] public int? WeekDay { get; private set; }


        /// <summary>
        /// <see cref="TitleModel.Season"/> of title
        /// </summary>
        public Season Season => (Season)Code!;

        /// <summary>
        /// <see cref="CISDaysOfWeek"/> day on which the title was released
        /// </summary>
        public CISDaysOfWeek DayOfWeek => (CISDaysOfWeek)WeekDay!;


        /// <summary>
        /// Override on .Tostring()
        /// </summary>
        /// <returns><see cref="String"/> <see cref="Year"/> <see cref="DayOfWeek"/> as <see cref="string"/></returns>
        public override string ToString() => $"{String!} {Year!} {DayOfWeek}";
    }
}
