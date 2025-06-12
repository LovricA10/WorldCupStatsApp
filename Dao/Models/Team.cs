using Newtonsoft.Json;

namespace Dao.Models
{
    public partial class Team
    {
        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("fifa_code")]
        public string? Code { get; set; }

        [JsonProperty("goals")]
        public long Goals { get; set; }

        [JsonProperty("penalties")]
        public long Penalties { get; set; }

        public override string ToString()
        => $"{Country} ({Code})";
    }
}
