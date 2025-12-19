using System.Collections.Generic;
using RPGAdventureTome.Actors;

namespace RPGAdventureTome.Capabilities
{

    public class Health
    {
        private int maxHealth;
        private int currentHealth;

        public Health(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;
        }

        public int getCurrentHealth()
        {
            return currentHealth;
        }

        /// Some Documentation here
        public void UpdateHealth(int healthChange){
            currentHealth += healthChange;
            
            if (currentHealth >= maxHealth)
                currentHealth = maxHealth;
        }
    }
}