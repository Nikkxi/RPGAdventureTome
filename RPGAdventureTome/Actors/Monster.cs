using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTome.Actors
{
    public class Monster : Actor
    {
        private Breed breed;

        private int maxHealth;
        private int currentHealth;

        private bool isAlive = true;

        internal Monster(Breed breed)
        {
            this.breed = breed;
            maxHealth = breed.getHealth();
        }

        public String Name()
        {
            return breed.GetType().Name;
        }

        public int getAttack()
        {
            return breed.getAttack();
        }

        public void takeDamage(int damage)
        {
            currentHealth -= damage;

            if(currentHealth <= 0)
            {
                isAlive = false;
            }
        }

        public void heal(int healthToAdd)
        {
            currentHealth += healthToAdd;
            
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}
