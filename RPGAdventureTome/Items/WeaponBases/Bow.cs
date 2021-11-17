using System;
using System.Collections.Generic;
using System.Text;
using AdventureTome.Capabilities;

namespace AdventureTome.Items.WeaponBases
{
    public class Bow : Item
    {
        public Bow()
        {
            ranged = new Attack(2, 6);
        }


    }
}
