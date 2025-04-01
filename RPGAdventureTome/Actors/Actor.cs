using System;
using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Actors
{
    public abstract class Actor(Health health) : Attackable, Healable
    {
        public int getCurrentHealth()
        {
            return health.getCurrentHealth();
        }
        public void TakeDamage(int damage)
        {
            health.UpdateHealth(-damage);
            Console.WriteLine($"{this.GetType().Name} takes {damage} damage");
            Console.WriteLine($"{this.GetType().Name} has {health.getCurrentHealth()} hp left");
            Console.WriteLine();
        }

        public void OnDeath()
        {
            Console.WriteLine("OnDeath triggered!");
        }

        public void Heal(int healAmount)
        {
            health.UpdateHealth(healAmount);
            Console.WriteLine($"{this.GetType().Name} heals for {healAmount}");
            Console.WriteLine($"{this.GetType().Name} has {health.getCurrentHealth()} hp left");
        }
    }
}
