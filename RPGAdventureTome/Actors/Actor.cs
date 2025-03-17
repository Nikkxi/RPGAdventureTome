using System.Collections.Generic;
using RPGAdventureTome.Items.Equipment;

namespace RPGAdventureTome.Actors
{
    public abstract class Actor
    {
        public List<Equipment> Equipment;

        public abstract void OnDeath();

        public abstract void TakeDamage(int damage);
        
    }
}
