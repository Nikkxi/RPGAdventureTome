using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using RPGAdventureTome.Actors;
using RPGAdventureTome.Capabilities.Effects;

namespace RPGAdventureTome.Capabilities
{

    [Serializable]
    public class Attack
    {

        public int minDamage {get;set;}
        public int maxDamage {get;set;}
        public int range {get;set;} // from 0-n tile range


        public Attack(){
            // Default Null option
            minDamage = 0;
            maxDamage = 0;
            range = 0;
        }

        public Attack(int MinDamage, int MaxDamage, int Range){
            this.minDamage = MinDamage;
            this.maxDamage = MaxDamage;
            this.range = Range;
        }

        public void Perform(Actor target){
            Random r = new Random();
            int damage = r.Next(minDamage, maxDamage);
            target.TakeDamage(damage);
        }
    }
}
