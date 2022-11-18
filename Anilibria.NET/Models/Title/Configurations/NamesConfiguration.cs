using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    public class NamesConfiguration
    {
        [JsonProperty("ru")] public string? Russian { get; private set; }

        [JsonProperty("en")] public string? English { get; private set; }

        [JsonProperty("alternative")] public string? Alternative { get; private set; }

        public override string ToString() => Russian;
    }
}
