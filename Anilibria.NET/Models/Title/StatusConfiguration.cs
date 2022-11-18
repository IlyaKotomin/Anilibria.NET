﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anilibria.NET.Models.Title
{
    public class StatusConfiguration
    {
        [JsonProperty("string")] public string? String { get; set; }

        [JsonProperty("code")] public int Code { get; set; }

        public TitleStatus Status => (TitleStatus)Code;

        public override string ToString() => String;
    }
}