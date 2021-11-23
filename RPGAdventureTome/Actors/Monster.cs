using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGAdventureTome.Actors
{
    public class Monster : Actor
    {
        public Breed breed;

        private int maxHealth;
        private int currentHealth;

        private bool isAlive = true;

        internal Monster(Breed breed)
        {
            this.breed = breed;
            maxHealth = breed.health;
        }

        public String Name()
        {
            return breed.name;
        }

        public int getAttack()
        {
            return breed.attack;
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
