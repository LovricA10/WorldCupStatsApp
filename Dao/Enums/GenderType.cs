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
    public enum GenderType
    {
        [EnumMember(Value = "male")]
        Male,
        [EnumMember(Value = "female")]
        Female
    }
}
