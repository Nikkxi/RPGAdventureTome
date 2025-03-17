using System.Collections.Generic;
using RPGAdventureTome.Actors;

namespace RPGAdventureTome.Capabilities
{

    public class Health
    {
        private int maxHealth;
        private int currentHealth;
        private List<Actor> observers;

        public Health(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;
            observers = new List<Actor>();
        }

        /// Some Documentation here
        public void TakeDamage(int damage){
            currentHealth -= damage;

            if (currentHealth <= 0)
                onDeath();
        }

        public void receiveHealing(int health){
            currentHealth += health;

            if (currentHealth >= maxHealth)
                currentHealth = maxHealth;
        }

        private void onDeath(){
            foreach(Actor actor in observers){
                actor.OnDeath();
            }
        }

        public void RegisterObserver(Actor actor){
            observers.Add(actor);
        }
    }
}