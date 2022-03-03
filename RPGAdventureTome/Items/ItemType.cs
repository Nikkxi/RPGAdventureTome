using System.Runtime.Serialization;

namespace RPGAdventureTome.Items
{
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
        [EnumMember(Value = "POTION")]
        POTION
    }
}