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

        [EnumMember(Value = "Match for third place")]
        MatchForThirdPlace,

        [EnumMember(Value = "Quarter-finals")]
        QuarterFinals,

        [EnumMember(Value = "Quarter-final")]
        QuarterFinal,


        [EnumMember(Value = "Round of 16")]
        RoundOf16,

        [EnumMember(Value = "Semi-finals")]
        SemiFinals,

        [EnumMember(Value = "Semi-final")]
        SemiFinal,

     
    };
}
