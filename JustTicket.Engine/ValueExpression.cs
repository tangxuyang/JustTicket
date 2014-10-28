using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JustTicket.Engining.Actions;

namespace JustTicket.Engining
{
    public class ValueExpression
    {
        public string Expression
        {  
            get
            {
                if (this.PropertyInfo != null)
                {
                    return this.PropertyInfo.GetValue(Action,null).ToString();
                }
                return null;
            }
        }

        public string OrginalExpress { get; set; }

        public JustTicket.Engining.Actions.Action Action
        {
            get;
            set;
        }

        public PropertyInfo PropertyInfo { get; set; }

        public string Calculate()
        {
            string expression = Expression;
            if (expression.Contains("{"))//Variable
            {
                return Action.Variables.Resolve(Action, expression);
            }

            if (expression.Contains("$"))//Object.Property
            {
                
                return null;
            }
            return Expression;
        }
    }
}
