using System.Collections.Generic;

namespace RPGAdventureTome.Actors
{
    public abstract class Actor
    {

        public abstract void OnDeath();

        public abstract void takeDamage(int damage);
        
    }
}
