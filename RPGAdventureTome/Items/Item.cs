using RPGAdventureTome.Capabilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RPGAdventureTome.Items
{
    public class Item
    {
        // maybe use this paradigm ???
        public string ItemName;

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ItemType ItemType;
        public Attack? Melee;
        public Attack? Range;
        public Defense? Defense;
        public List<Use>? Uses;
    }
}
