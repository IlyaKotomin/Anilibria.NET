using Newtonsoft.Json;
using Anilibria.NET.Models.TitleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models
{
    public class Schedule
    {

        [JsonProperty("day")] public int Day { get; private set; }

        [JsonProperty("list")] public List<Title>? Titles { get; private set; }

        public CISDaysOfWeek DayOfWeek => (CISDaysOfWeek)Day;

        public override string ToString() => DayOfWeek.ToString();
    }
}
