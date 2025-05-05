using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Dao.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StageName 
    {
        [EnumMember(Value = "Final")]
        Final,

        [EnumMember(Value = "First stage")]
        FirstStage,

        [EnumMember(Value = "Play-off for third place")]
        PlayOffForThirdPlace,

        [EnumMember(Value = "Quarter-finals")]
        QuarterFinals,

        [EnumMember(Value = "Round of 16")]
        RoundOf16,

        [EnumMember(Value = "Semi-finals")]
        SemiFinals
    };
}
