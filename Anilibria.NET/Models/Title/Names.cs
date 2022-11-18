using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class Names
    {
        [JsonProperty("ru")] public static string? Russian { get; set; }

        [JsonProperty("en")] public static string? English { get; set; }

        [JsonProperty("alternative")] public static string? Alternative { get; set; }

        public override string ToString() => Russian;
    }
}
