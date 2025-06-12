using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Dao.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Time 
    {
        [EnumMember(Value = "full-time")]
        FullTime 
    };
}
