using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Actors
{
    public class Monster : Actor
    {
        readonly Breed breed;
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

        public override void TakeDamage(int damage)
        {
            health.TakeDamage(damage);
        }

        public void Heal(int healing)
        {
            health.receiveHealing(healing);
        }

        public override void OnDeath(){
            // on death trigger
        }        
    }
}
