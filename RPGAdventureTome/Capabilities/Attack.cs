using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Capabilities
{
    public class Attack
    {
        public int MinDamage;
        public int MaxDamage;

        public int hit()
        {
            Random r = new Random();
            return r.Next(MinDamage, MaxDamage);
        }
    }
}
