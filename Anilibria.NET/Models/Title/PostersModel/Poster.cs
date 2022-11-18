using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title.PostersModel
{
    public class Poster
    {
        [JsonProperty("url")] public string? Url { get; set; }

        [JsonProperty("raw_base64_file")] public string? Base64 { get; set; }

        public override string ToString() => Url;
    }
}
