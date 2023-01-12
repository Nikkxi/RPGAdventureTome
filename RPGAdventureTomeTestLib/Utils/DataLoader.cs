using System;
using RPGAdventureTome.Actors;
using RPGAdventureTome.Items;
using RPGAdventureTome.Capabilities;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPGAdventureTomeTestLib.Utils
{
    class DataLoader
    {
        private readonly string DATA_DIRECTORY   = "./Data/";

        JsonSerializerOptions serializationOptions;

        public DataLoader()
        {
            serializationOptions = new JsonSerializerOptions();
            serializationOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        }

        private string ReadJsonFromFile(string fileName) {

            string jsonData = File.ReadAllText(DATA_DIRECTORY + fileName + ".json");

            return jsonData;
        }

        public List<Breed> LoadMonsterBreeds()
        {
            List<Breed> breedList = new List<Breed>();

            JsonDocument monsterBreeds = JsonSerializer.Deserialize<JsonDocument>(ReadJsonFromFile("MonsterBreeds"), serializationOptions);

            var enumerator = monsterBreeds.RootElement.EnumerateArray();

            // iterate through to create base monster type
            foreach(JsonElement monster in enumerator)
            {
                var parent = monster.GetProperty("parent").GetString();

                if(parent.Length == 0)
                {
                    var name = monster.GetProperty("name").GetString();
                    var health = monster.GetProperty("health").GetInt32();
                    var attack = monster.GetProperty("attack").GetInt32();

                    breedList.Add(new Breed(name, health, attack));
                }
            }

            // iterate through to create monster sub-types
            foreach (JsonElement monster in enumerator)
            {
                var parent = monster.GetProperty("parent").GetString();

                if (parent.Length > 0)
                {
                    var name = monster.GetProperty("name").GetString();
                    var health = monster.GetProperty("health").GetInt32();
                    var attack = monster.GetProperty("attack").GetInt32();

                    var parentBreed = breedList.Find(p => p.name.Equals(parent));
                    breedList.Add(new Breed(parentBreed, name, health, attack));
                }
            }

            return breedList;
        }

        public List<Item> loadWeapons(){
            List<Item> itemList = new List<Item>();

            var items = JsonSerializer.Deserialize<JsonDocument>(ReadJsonFromFile("Weapons"), serializationOptions);
            var enumerator = items.RootElement.EnumerateArray();

            foreach(JsonElement item in enumerator)
            {
                //Console.WriteLine(item.GetProperty("ItemName").GetString());

                var itemName = item.GetProperty("ItemName").GetString();
                var itemType = item.GetProperty("ItemType").Deserialize<ItemType>();
                var melee = item.GetProperty("Melee").Deserialize<Attack>();
                var range = item.GetProperty("Range").Deserialize<Attack>();
                var defense = item.GetProperty("Defense").Deserialize<Defense>();
                var uses = item.GetProperty("Uses").Deserialize<List<Use>>();

                itemList.Add(new Item(itemName, itemType, melee, range, defense, uses));
            }

            return itemList;
        }

        public List<Item> loadArmor(){
            List<Item> itemList = new List<Item>();

            var items = JsonSerializer.Deserialize<JsonDocument>(ReadJsonFromFile("Armor"), serializationOptions);
            var enumerator = items.RootElement.EnumerateArray();

            foreach(JsonElement item in enumerator)
            {
                //Console.WriteLine(item.GetProperty("ItemName").GetString());

                var itemName = item.GetProperty("ItemName").GetString();
                var itemType = item.GetProperty("ItemType").Deserialize<ItemType>();
                var melee = item.GetProperty("Melee").Deserialize<Attack>();
                var range = item.GetProperty("Range").Deserialize<Attack>();
                var defense = item.GetProperty("Defense").Deserialize<Defense>();
                var uses = item.GetProperty("Uses").Deserialize<List<Use>>();

                itemList.Add(new Item(itemName, itemType, melee, range, defense, uses));
            }

            return itemList;
        }
    }
}
