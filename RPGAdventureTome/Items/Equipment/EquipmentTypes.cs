using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace RPGAdventureTome.Items.Equipment
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EquipmentType
    {
        [EnumMember(Value = "WEAPON")] WEAPON,
        [EnumMember(Value = "ARMOR")] ARMOR,
        [EnumMember(Value = "ACCESSORY")]  ACCESSORY
    }
    
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum WeaponType
    {
        [EnumMember(Value = "SWORD")] SWORD,
        [EnumMember(Value = "DAGGER")] DAGGER,
        [EnumMember(Value = "HAMMER")] HAMMER,
        [EnumMember(Value = "STAFF")] STAFF,
        [EnumMember(Value = "BOW")] BOW,
        [EnumMember(Value = "")] NULL
    }
}