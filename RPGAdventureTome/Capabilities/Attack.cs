using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureTome.Capabilities
{
    public abstract class Attack
    {
        private int minDamage;
        private int maxDamage;

        public abstract void hit();
    }
}
