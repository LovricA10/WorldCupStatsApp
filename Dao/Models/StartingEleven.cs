﻿using Dao.Enums;
using Newtonsoft.Json;

namespace Dao.Models
{
    public partial class StartingEleven
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }
    }
}
