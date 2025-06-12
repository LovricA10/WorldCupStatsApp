using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Dao.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GenderType
    {
        [EnumMember(Value = "male")]
        Male,
        [EnumMember(Value = "female")]
        Female
    }
}
