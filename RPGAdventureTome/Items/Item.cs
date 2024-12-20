using System;
using System.Collections.Generic;
using System.Text.Json;

using RPGAdventureTome.Actors;
using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Items
{
    public class Item
    {
        public string ItemName {get;set;}
        public string Description {get;set;}

        #nullable enable
        public Attack? Attack {get;set;}
        public Defense? Defense {get;set;}
        public List<Usable?> Usables {get;set;}


        public Item()
        {
            this.ItemName = "";
            this.Description = "";
            this.Usables = new List<Usable?>();
        }

        public Item(string name, string description)
        {
            this.ItemName = name;
            this.Description = description;
            this.Usables = new List<Usable?>();
        }

        public Item(string _name, string _desciption, Attack _attack, Defense _defense){
            this.ItemName = _name;
            this.Description = _desciption;
            this.Attack = _attack;
            this.Defense = _defense;
            Usables = new List<Usable?>();
        }

        public Item(string _name, string _desciption, Attack _attack, Defense _defense, List<Usable?> _Usables){
            this.ItemName = _name;
            this.Description = _desciption;
            this.Attack = _attack;
            this.Defense = _defense;
            Usables = _Usables;
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
