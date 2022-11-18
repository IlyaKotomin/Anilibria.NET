using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.Configurations
{
    public class StatusConfiguration
    {
        [JsonProperty("string")] public string? String { get; private set; }

        [JsonProperty("code")] public int Code { get; private set; }

        public TitleStatus Status => (TitleStatus)Code;

        public override string ToString() => String;
    }
}
