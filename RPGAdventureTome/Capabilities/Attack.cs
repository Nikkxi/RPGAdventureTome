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

        public int MinDamage {get;set;}
        public int MaxDamage {get;set;}
        public int Range {get;set;} // from 0-n tile range

        #nullable enable
        public List<Effect?> OnHitEffects {get;set;}

        public Attack(){
            // Default Null option
            MinDamage = 0;
            MaxDamage = 0;
            Range = 0;
            OnHitEffects = new List<Effect?>();
            OnHitEffects.Add(new NoEffect());
        }

        public Attack(int MinDamage, int MaxDamage, int Range){
            this.MinDamage = MinDamage;
            this.MaxDamage = MaxDamage;
            this.Range = Range;
            OnHitEffects = new List<Effect?>();
            OnHitEffects.Add(new NoEffect());
        }

        public Attack(int MinDamage, int MaxDamage, int Range, List<Effect?> OnHitEffects){
            this.MinDamage = MinDamage;
            this.MaxDamage = MaxDamage;
            this.Range = Range;
            this.OnHitEffects = OnHitEffects;
        }

        public void perform(Actor target){
            Random r = new Random();
            int damage = r.Next(MinDamage, MaxDamage);
            target.takeDamage(damage);
        }
    }
}
