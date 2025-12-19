using System;
using System.Collections.Generic;

using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Items.Equipment
{
    public class Equipment : Item, Equipable
    {

        #nullable enable
        public EquipmentType equipmentType { get; set; }
        public Attack? attack {get;set;}
        public Defense? defense {get;set;}
        public List<Usable?> usables {get;set;}
        

        public Equipment(string name, string description, EquipmentType equipmentType)
            : base(name, description,  ItemType.EQUIPMENT)
        {
            this.equipmentType = equipmentType;
            this.usables = new List<Usable?>();
        }

        public void AddAttack(Attack attack)
        {
            this.attack = attack;
        }

        public void AddDefense(Defense defense)
        {
            this.defense = defense;
        }

        public void AddUsable(Usable usable)
        {
            this.usables.Add(usable);
        }

        public void Equip()
        {
            Console.WriteLine($"\nEquipping {name}");
        }

        public void UnEquip()
        {
            Console.WriteLine($"\nUn-equipping {name}");
        }
        
        public override string ToString()
        {
            string str = "";
            str += $"\nItem name: {name}";
            str += $"\nItem Description: {description}";
            str += $"\nEquipment Type: {equipmentType}";

            return str;
        }
    }
}
