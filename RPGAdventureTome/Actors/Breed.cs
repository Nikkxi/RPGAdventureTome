namespace RPGAdventureTome.Actors
{
    public class Breed
    {
        public Breed parent;
        public string name;
        public int health;
        public int attack;

        public Breed(string name, int health, int attack)
        {
            this.name = name;
            this.health = health;
            this.attack = attack;
        }

        public Breed(Breed parent, string name)
        {
            this.parent = parent;
            this.name = name;
            this.health = parent.health;
            this.attack = parent.attack;
        }

        public Breed(Breed parent, string name, int health, int attack)
        {
            this.parent = parent;
            this.name = name;
            this.health = health;
            this.attack = attack;
        }

        public Monster newMonster() => new Monster(this);
    }
}
