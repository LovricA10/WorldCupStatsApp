﻿using Newtonsoft.Json;

namespace Dao.Models
{
    public class MatchTeam
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("alternate_name")]
        public object? AlternateName { get; set; }

        [JsonProperty("fifa_code")]
        public string? FifaCode { get; set; }

        [JsonProperty("group_id")]
        public long GroupId { get; set; }

        [JsonProperty("group_letter")]
        public string? GroupLetter { get; set; }

        public override string ToString()
        => $"{Country?.ToUpper()} ({FifaCode?.ToUpper()})";
    }
}
