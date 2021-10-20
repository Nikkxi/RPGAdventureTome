using AdventureTome.Actors;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPGAdventureTomeTestLib.Utils
{
    class DataLoader
    {
        private readonly string FILE_PATH = "Data/";

        public DataLoader()
        {

        }

        private string ReadJsonFromFile(string fileName) {

            string jsonData = File.ReadAllText(FILE_PATH + fileName + ".json");

            return jsonData;
        }

        public List<Breed> LoadMonsterBreeds()
        {
            List<Breed> breedList = new List<Breed>();

            JsonDocument monsterBreeds = JsonSerializer.Deserialize<JsonDocument>(ReadJsonFromFile("MonsterBreeds"));

            var enumerator = monsterBreeds.RootElement.EnumerateArray();

            foreach(JsonElement monster in enumerator)
            {
                var name = monster.GetProperty("name").GetString();
                var health = monster.GetProperty("health").GetInt32();
                var attack = monster.GetProperty("attack").GetInt32();

                breedList.Add(new Breed(name, health, attack));
            }

            foreach(Breed monster in breedList)
            {

            }

            return breedList;
        }
    }
}
