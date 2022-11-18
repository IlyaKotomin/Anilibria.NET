using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.Configurations
{
    public class SeasonConfiguration
    {
        [JsonProperty("string")] public string? String { get; private set; }

        [JsonProperty("code")] public int Code { get; private set; }

        [JsonProperty("year")] public int Year { get; private set; }

        [JsonProperty("week_day")] public int WeekDay { get; private set; }

        public Season Season => (Season)Code;

        public override string ToString() => $"{String!} {Year!}";
    }
}
