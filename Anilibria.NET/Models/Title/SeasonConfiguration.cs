﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class SeasonConfiguration
    {
        [JsonProperty("string")] public string? String { get; set; }

        [JsonProperty("code")] public int Code { get; set; }

        [JsonProperty("year")] public int Year { get; set; }
        
        [JsonProperty("week_day")] public int WeekDay { get; set; }

        public Season Season => (Season)Code;

        public override string ToString() => $"{String!} {Year!}";
    }
}
