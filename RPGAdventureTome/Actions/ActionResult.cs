using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureTome.Actions
{
    public class ActionResult
    {
        public static readonly ActionResult Success = new ActionResult(true, true);
        public static readonly ActionResult Fail = new ActionResult(false, true);
        public static readonly ActionResult NotDone = new ActionResult(true, false);

        private Action alternative;
        private bool succeeded;
        private bool done;

        public ActionResult(bool s, bool d)
        {
            succeeded = s;
            done = d;
        }
    }
}
