using System;
using System.Collections.Generic;
using RPGAdventureTome.Actors;
using RPGAdventureTome.Capabilities.Effects;

namespace RPGAdventureTome.Capabilities
{
    public class Attack
    {
        public int MinDamage;

        public int MaxDamage;

        public int Range; // from 0-n tile range

        public List<Effect>? OnHitEffects;

        public Attack(){
            // Default Null option
            MinDamage = 0;
            MaxDamage = 0;
            Range = 0;
            OnHitEffects.Add(new NoEffect());
        }

        public Attack(int MinDamage, int MaxDamage, int Range){
            this.MinDamage = MinDamage;
            this.MaxDamage = MaxDamage;
            this.Range = Range;
            OnHitEffects.Add(new NoEffect());
        }

        public void perform(Actor target){
            Random r = new Random();
            int damage = r.Next(MinDamage, MaxDamage);
            target.takeDamage(damage);
        }
    }
}
