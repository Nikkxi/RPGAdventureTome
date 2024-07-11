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
        public string ItemName {get;set;}
        public string Description {get;set;}
        public Attack? Attack {get;set;}
        public Defense? Defense {get;set;}
        public List<Use?> Uses {get;set;}


        public Item()
        {
            this.ItemName = "";
            this.Description = "";
            this.Uses = new List<Use?>();
        }

        public Item(string name, string description)
        {
            this.ItemName = name;
            this.Description = description;
            this.Uses = new List<Use>();
        }

        public Item(string _name, string _desciption, Attack _attack, Defense _defense){
            this.ItemName = _name;
            this.Description = _desciption;
            this.Attack = _attack;
            this.Defense = _defense;
            Uses = new List<Use>();
        }

        public Item(string _name, string _desciption, Attack _attack, Defense _defense, List<Use> _uses){
            this.ItemName = _name;
            this.Description = _desciption;
            this.Attack = _attack;
            this.Defense = _defense;
            Uses = new List<Use?>();
            Uses = _uses;
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
