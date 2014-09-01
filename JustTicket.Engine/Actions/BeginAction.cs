using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining.Actions
{
    public class BeginAction : ComponentAction
    {
        public override void Execute()
        {
            base.Execute();

            foreach(var action in ChildActions)
            {
                action.Execute();
            }
        }
    }
}
