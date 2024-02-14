using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Capabilities
{
    public abstract class Use
    {
        public abstract void use();
    }
}


namespace RPGAdventureTome.Capabilities.Uses
{
    public class NullUse : Use
    {
        public override void use()
        {
            // does nothing
        }
    }
}
