using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Actors
{

    public class Player : Actor
    {

        public Player(): base(new Health(10)){
            
        }

        public Player(Health health): base(health){
            
        }
    }
}
