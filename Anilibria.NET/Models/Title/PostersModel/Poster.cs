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
        [JsonProperty("url")] public string? Url { get; private set; }

        [JsonProperty("raw_base64_file")] public string? Base64 { get; private set; }

        public override string ToString() => Url;
    }
}
