using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining;

namespace JustTicket.Engining.Actions
{
    public class IfAction : ComponentAction
    {
        public string Condition
        {
            get;
            set;
        }

        public override void Execute()
        {
            base.Execute();

            bool b = ExpressionHelper.GetResult<bool>(Condition);
            if(b)
            {
                ChildActions[0].Execute();
            }
            else
            {
                if(ChildActions.Count>1)
                {
                    ChildActions[1].Execute();
                }
            }
        }
    }
}
