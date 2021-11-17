using System;
namespace RPGAdventureTome.Capabilities
{
    public class RangedAttack : Attack
    {
        int range;
        
        public RangedAttack(int min, int max) : base(min, max)
        {
            range = 30;
        }

        public RangedAttack(int min, int max, int range) : base(min, max)
        {
            this.range = range;
        }

        public override void hit()
        {
            
        }
    }
}

