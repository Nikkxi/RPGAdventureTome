using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Actors
{
    public class Monster : Actor
    {
        readonly Breed breed;

        public Monster(Breed breed) : base(new Health(10))
        {
            this.breed = breed;
        }

        public string GetName()
        {
            return breed.name;
        }    
    }
}
