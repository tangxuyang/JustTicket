using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    public class IfAction : ComponentAction
    {
        private string condition;

        public string Condition
        {
            get
            {
                return GetPropertyValue<string>("Condition", this);
            }
            set
            {
                condition = value;
            }
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
