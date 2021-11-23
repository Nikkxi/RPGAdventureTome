using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Capabilities
{
    public abstract class Defense
    {
        private int armor;
        private int dodgeBonus;
        public abstract void Defend();
    }
}
