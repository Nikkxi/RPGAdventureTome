using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace RPGAdventureTome.Capabilities
{
    public class Attack
    {
        [JsonInclude]
        public int MinDamage;

        [JsonInclude]
        public int MaxDamage;

        public int hit()
        {
            Random r = new Random();
            return r.Next(MinDamage, MaxDamage);
        }
    }
}
