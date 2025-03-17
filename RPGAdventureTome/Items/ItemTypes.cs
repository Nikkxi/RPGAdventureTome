using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RPGAdventureTome.Items
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemType{
        [EnumMember(Value = "EQUIPMENT")]
        EQUIPMENT,
        [EnumMember(Value = "CONSUMABLE")]
        CONSUMABLE,
        [EnumMember(Value = "MATERIAL")]
        MATERIAL
    }
}