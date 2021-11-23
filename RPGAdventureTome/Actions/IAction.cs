using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Actions
{
    interface IAction
    {
        public ActionResult perform();
    }
}
