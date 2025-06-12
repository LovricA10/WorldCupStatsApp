using Dao.Enums;
using Newtonsoft.Json;

namespace Dao.Models
{
    public partial class TeamEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public TypeOfEvent TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string? Player { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }
    }
}
