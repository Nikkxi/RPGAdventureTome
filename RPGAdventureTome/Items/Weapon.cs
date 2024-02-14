using RPGAdventureTome.Capabilities;

namespace RPGAdventureTome.Items
{
    
    public class Weapon : Item
    {

        public Attack attack;
        public WeaponType wType;


        public Weapon(string name, string description, Attack attack, WeaponType type): base(name, description)
        {
            this.attack = attack;
            this.wType = type;
        }

    }
}