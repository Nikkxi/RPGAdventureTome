using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Actors
{
    public class Monster : Actor
    {
        private Breed breed;
        private Health health;

        public Monster(Breed breed)
        {
            this.breed = breed;
            this.health = new Health(breed.health);
            this.health.RegisterObserver(this);
        }

        public string GetName()
        {
            return breed.name;
        }

        public override void takeDamage(int damage)
        {
            health.takeDamage(damage);
        }

        public void heal(int healing)
        {
            health.receiveHealing(healing);
        }

        public override void OnDeath(){
            // on death trigger
        }        
    }
}
