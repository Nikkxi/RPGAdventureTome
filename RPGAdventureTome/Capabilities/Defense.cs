using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RPGAdventureTome.Capabilities
{
    public class Defense
    {
        [JsonInclude]
        public int Armor;
        [JsonInclude]
        public int DodgeChance;
    }
}
