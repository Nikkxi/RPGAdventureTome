using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Capabilities
{
    public abstract class Attack
    {
        internal int minDamage;
        internal int maxDamage;

        public Attack(int min, int max)
        {
            minDamage = min;
            maxDamage = max;
        }

        public abstract void hit();
    }
}
