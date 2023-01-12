using RPGAdventureTome.Capabilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using RPGAdventureTome.Actors;

namespace RPGAdventureTome.Items
{
    public class Item
    {
        [JsonInclude]
        public string ItemName;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemType ItemType;
        
        [JsonInclude]
        public Attack? Melee;

        [JsonInclude]
        public Attack? Range;

        [JsonInclude]
        public Defense? Defense;

        [JsonInclude]
        public List<Use>? Uses;

        public Item() : this("", ItemType.NULL, null, null, null, null)
        {
            
        }
        public Item(string itemName, ItemType itemType, Attack melee, Attack range, Defense defense, List<Use> uses)
        {
            this.ItemName = itemName;
            this.ItemType = itemType;
            this.Melee = melee;
            this.Range = range;
            this.Defense = defense;
            this.Uses = uses;
        }

        public void Print()
        {
            Console.WriteLine("\nItem Name: " + ItemName);
            Console.WriteLine("ItemType: " + ItemType);
            if(Melee != null) Console.WriteLine("Melee: " + Melee);
            if(Range != null) Console.WriteLine("Range: " + Range);
            if(Defense != null) Console.WriteLine("Defense: " + Defense);
            if(Uses != null) Console.WriteLine("Uses: " + Uses);
        }

        public override string ToString()
        {
            string str = "";
            str += $"\nItem Name: {ItemName}";
            str += $"\nItemType: {ItemType}";
            if(Melee != null) str += $"\nMelee: {Melee.MaxDamage}";
            if(Range != null) str += $"\nRange: {Range.MaxDamage}";
            if(Defense != null) str += $"\nDefense: {Defense.Armor}";
            if(Uses != null) str += "$\nUses: {Uses}";

            return str;
        }
    }
}
