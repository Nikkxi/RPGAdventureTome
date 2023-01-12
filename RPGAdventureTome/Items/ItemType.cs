using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RPGAdventureTome.Items
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ItemType{
        [EnumMember(Value = "SWORD")]
        SWORD,
        [EnumMember(Value = "DAGGER")]
        DAGGER,
        [EnumMember(Value = "HAMMER")]
        HAMMER,
        [EnumMember(Value = "STAFF")]
        STAFF,
        [EnumMember(Value = "BOW")]
        BOW,
        [EnumMember(Value = "ARMOR")]
        ARMOR,
        [EnumMember(Value = "POTION")]
        POTION,
        NULL
    }
}