﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.TitleModel.PlayerModel.EpisodeModel
{
    public class Episode
    {
        [JsonProperty("serie")] public string? Number { get; private set; }

        [JsonProperty("preview")] public string? Preview { get; private set; }

        [JsonProperty("skips")] public Skips? Skips { get; private set; }

        [JsonProperty("hls")] public HotLinks? HotLinks { get; private set; }
        
        [JsonProperty("created_timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))] public DateTime CreatedDate { get; private set; }

        public override string ToString() => $"Serie {Number}";
    }
}
