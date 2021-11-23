using System;
using System.Collections.Generic;
using System.Text;

namespace RPGAdventureTome.Actions
{
    public abstract class Action : IAction
    {
        public abstract ActionResult perform();

        protected ActionResult Succeed() => ActionResult.Success;

        protected ActionResult Fail() => ActionResult.Fail;

        protected ActionResult Fail(string msg)
        {
            Console.WriteLine(msg);
            return ActionResult.Fail;
        }

        protected ActionResult NotDone() => ActionResult.NotDone;

        protected ActionResult Alternate(Action action) => action.perform();
        
    }
}
