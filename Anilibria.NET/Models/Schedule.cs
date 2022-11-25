using Newtonsoft.Json;
using Anilibria.NET.Models.TitleModel;

namespace Anilibria.NET.Models
{
    /// <summary>
    /// Title entry schedules for a specific day
    /// </summary>
    public class Schedule
    {
        /// <summary>
        /// Selected day as int
        /// </summary>
        [JsonProperty("day")] public int Day { get; private set; }


        /// <summary>
        /// Titles coming out on the selected date 
        /// </summary>
        [JsonProperty("list")] public List<Title>? Titles { get; private set; }


        /// <summary>
        /// Selected day as enum
        /// </summary>
        public CISDaysOfWeek DayOfWeek => (CISDaysOfWeek)Day;


        /// <summary>
        /// Override on .ToString()
        /// </summary>
        /// <returns>Selected day name</returns>
        public override string ToString() => DayOfWeek.ToString();
    }
}
