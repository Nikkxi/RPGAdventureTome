using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureTome.Actors
{
    public class Breed
    {
        private Breed parent;
        private int health;
        private int attack;

        public Breed(Breed breed, int health, int attack)
        {
            this.parent = breed;
            this.health = health;
            this.attack = attack;
        }

        public Breed(int health, int attack)
        {
            this.parent = null;
            this.health = health;
            this.attack = attack;
        }


        public int getHealth() { 
            if(health != 0 || parent == null)
                return health;

            return parent.getHealth();
        }

        public int getAttack() {
            if (attack > 0 || parent == null)
                return attack;

            return parent.getAttack();
        }

        public Breed getParent()
        {
            return parent;
        }

        public Monster newMonster() => new Monster(this);
    }
}
