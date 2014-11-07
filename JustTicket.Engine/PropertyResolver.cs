using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JustTicket.Engining.Actions;

namespace JustTicket.Engining
{
    public class PropertyResolver
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

        public virtual string Calculate()
        {
            string expression = OrginalExpress;
            if (expression.Contains("{"))//Variable
            {
                return Action.Variables.Resolve(Action, expression);
            }

            if (expression.Contains("$"))//Object.Property
            {
                string[] strs = expression.Split('.');
                string actionName = strs[0].TrimStart('$');
                string propertyName = strs[1];

                JustTicket.Engining.Actions.Action action = GetActionFromContainer(actionName);
                if (action == null)
                {
                    throw new Exception(actionName+" doesn't exist.");
                }
                else
                {

                }
                return GetPropertyValue(propertyName, action).ToString();
            }
            return expression;
        }

        private JustTicket.Engining.Actions.Action GetActionFromContainer(string actionName)
        {
            JustTicket.Engining.Actions.Action container = Action.Container;
            JustTicket.Engining.Actions.Action action = null;
            while (container != null)
            {
                if (!container.NamedActions.ContainsKey(actionName))
                {
                    container = container.Container;
                    continue;
                }
                action = container.NamedActions[actionName];
                break;
            }

            return action;
        }

        private object GetPropertyValue(PropertyInfo pi, object obj)
        {
            return pi.GetValue(obj, null);
        }

        private object GetPropertyValue(string propertyName, object obj)
        {
            Type type = obj.GetType();
            PropertyInfo pi = type.GetProperty(propertyName);
            return GetPropertyValue(pi, obj);
        }
    }
}
