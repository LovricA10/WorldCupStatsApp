using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Dao.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Description 
    {
        [EnumMember(Value = "Clear Night")]
        ClearNight,

        [EnumMember(Value = "Cloudy")]
        Cloudy,

        [EnumMember(Value = "Cloudy Night")]
        CloudyNight,

        [EnumMember(Value = "Partly Cloudy")]
        PartlyCloudy,

        [EnumMember(Value = "Partly Cloudy Night")]
        PartlyCloudyNight,

        [EnumMember(Value = "Sunny")]
        Sunny
    };
}
