using System;
using System.Collections.Generic;
using System.Text;
using RPGAdventureTome.Modifiers;

namespace RPGAdventureTome.Items
{
    public class Weapon : Item
    {
        string baseType;
        int minDamage;
        int maxDamage;

        List<IModifier> modifiers;
        private readonly int MAX_MODIFIERS = 6;

        public Weapon(string baseType, int minDamage, int maxDamage)
        {
            this.baseType = baseType;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
        }

        public void AddModifier(IModifier mod)
        {
            if(modifiers.Count < MAX_MODIFIERS)
            {
                modifiers.Add(mod);
            }
        }
    }
}
