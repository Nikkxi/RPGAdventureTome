using System;

namespace RPGAdventureTome.Capabilities
{
    public class MeleeAttack : Attack
    {
        public MeleeAttack(int min, int max) : base(min, max)
        {
            
        }

        public override void hit()
        {
            Random r = new Random();
            r.Next(minDamage, maxDamage);
        }
    }
}

