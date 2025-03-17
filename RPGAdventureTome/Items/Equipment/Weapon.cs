using System.Collections.Generic;
using System.Text.Json.Serialization;
using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Items.Equipment
{
    
    public class Weapon : Equipment
    {

        [JsonInclude]
        public WeaponType weaponType;

        public Weapon(string name, string description, WeaponType weaponType)
            : base(name, description, EquipmentType.WEAPON)
        {
            this.weaponType = weaponType;
        }


        [JsonConstructor]
        public Weapon(string name, string description, WeaponType weaponType, Attack attack, Defense defense, List<Usable> usables)
            : base(name, description, EquipmentType.WEAPON)
        {
            this.weaponType = weaponType;
            this.attack = attack;
            this.defense = defense;
            this.usables = usables;
        }

    }
}