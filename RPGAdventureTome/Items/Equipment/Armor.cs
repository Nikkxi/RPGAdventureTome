using System.Collections.Generic;
using System.Text.Json.Serialization;
using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Items.Equipment;

public class Armor : Equipment
{
    public Armor(string name, string description)
        : base(name, description, EquipmentType.ARMOR)
    {
        
    }
    
    [JsonConstructor]
    public Armor(string name, string description, Attack attack, Defense defense, List<Usable> usables)
        : base(name, description, EquipmentType.ARMOR)
    {
        this.attack = attack;
        this.defense = defense;
        this.usables = usables;
    }
}