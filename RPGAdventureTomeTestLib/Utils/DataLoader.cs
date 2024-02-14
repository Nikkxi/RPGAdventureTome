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
            List<Item> weaponList = JsonSerializer.Deserialize<List<Item>>(ReadJsonFromFile("Weapons"));

            return weaponList;
        }

        public List<Item> loadArmor(){
            List<Item> armorList = JsonSerializer.Deserialize<List<Item>>(ReadJsonFromFile("Armor"));
            return armorList;
        }
    }
}
