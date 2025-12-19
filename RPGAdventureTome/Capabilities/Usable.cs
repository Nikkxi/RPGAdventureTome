using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Capabilities
{
    public abstract class Usable
    {
        public abstract void use();
    }
}


namespace RPGAdventureTome.Capabilities.Usables
{
    public class NullUse : Usable
    {
        public override void use()
        {
            // does nothing
        }
    }
}
