using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureTome.Actions
{
    interface IAction
    {
        public ActionResult perform();
    }
}
