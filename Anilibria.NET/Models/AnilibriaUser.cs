using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models
{
    public class AnilibriaUser
    {
        [JsonProperty("downloaded")] public ulong Downloaded { get; private set; }

        [JsonProperty("uploaded")] public ulong Uploaded { get; private set; }

        [JsonProperty("user")] public string? UserName { get; private set; }
    }
}
