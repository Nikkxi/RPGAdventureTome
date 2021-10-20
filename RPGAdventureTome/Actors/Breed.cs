namespace AdventureTome.Actors
{
    public class Breed
    {
        public string name;
        public int health;
        public int attack;

        public Breed(string name, int health, int attack)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
        }

        public Monster newMonster() => new Monster(this);
    }
}
