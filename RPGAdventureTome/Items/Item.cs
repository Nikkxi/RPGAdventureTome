using AdventureTome.Capabilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureTome.Items
{
    public abstract class Item
    {
        public ItemType itemType;




        // maybe use this paradigm ???
        public Attack melee;
        public Attack ranged;
        public Defense defense;
        public List<Use> uses;
    }
}
