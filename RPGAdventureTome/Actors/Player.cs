using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Actors
{

    class Player : Actor
    {

        private Health health;

        public Player(){
            this.health = new Health(10);
            health.RegisterObserver(this);
        }

        public Player(Health health){
            this.health = health;
            health.RegisterObserver(this);
        }

        public override void takeDamage(int damage){
            health.takeDamage(damage);
        }

        public override void OnDeath(){
            // game over trigger
        }
    }
}
