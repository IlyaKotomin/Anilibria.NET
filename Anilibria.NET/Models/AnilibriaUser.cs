using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models
{
    /// <summary>
    /// User Model
    /// </summary>
    public class AnilibriaUser
    {
        /// <summary>
        /// How many were downloaded via torrent
        /// </summary>
        [JsonProperty("downloaded")] public ulong Downloaded { get; private set; }


        /// <summary>
        /// How many were uploaded via torrent
        /// </summary>
        [JsonProperty("uploaded")] public ulong Uploaded { get; private set; }


        /// <summary>
        /// User name
        /// </summary>
        [JsonProperty("user")] public string? UserName { get; private set; }
    }
}
