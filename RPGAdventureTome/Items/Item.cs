using System;
using System.Collections.Generic;
using System.Text.Json;

using RPGAdventureTome.Actors;
using RPGAdventureTome.Capabilities;
using RPGAdventureTome.Capabilities.Uses;

namespace RPGAdventureTome.Items
{
    public class Item
    {
        public string ItemName;
        
        public string Description;

        public Attack? attack;
        public Defense? defense;
        public List<Use>? uses;


        public Item()
        {
            this.ItemName = "";
            this.Description = "";
            this.attack = new Attack();
            this.defense = new Defense();
            uses.Add(new NullUse());
        }

        public Item(string name, string description)
        {
            this.ItemName = name;
            this.Description = description;
        }

        public Item(string _name, string _desciption, Attack _attack, Defense _defense){
            this.ItemName = _name;
            this.Description = _desciption;
            this.attack = _attack;
            this.defense = _defense;
            uses.Add(new NullUse());
        }

        public void Print()
        {
            Console.WriteLine("\nItem Name: " + ItemName);
            Console.WriteLine("Item Description: " + Description);
        }

        public override string ToString()
        {
            string str = "";
            str += $"\nItem Name: {ItemName}";
            str += $"\nItem Description: {Description}";

            return str;
        }
    }
}
