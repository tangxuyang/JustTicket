using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JustTicket.Engining.Actions
{
    public class AssignmentAction : Action
    {
        string variable;
        public string Variable 
        { 
            get
            {
                return GetPropertyValue<string>("Variable", this);
            }
            set
            {
                variable = value;
            }


        }

        string value;
        public string Value
        {
            get
            {
                return GetPropertyValue<string>("Value", this);
            }
            set
            {
                this.value = value;
            }
        }

        public override void Execute()
        {
            base.Execute();
            Action container = Container;
            Dictionary<string,object> dic = null;
            while(container !=null)
            {
                if (container.Variables.Variables.ContainsKey(Variable))
                {
                    dic = container.Variables.Variables;
                    break;
                }

                container = container.Container;
            }

            if (dic == null)
                throw new Exception("Variable not found");

            if (!Value.Contains("$"))
            {
                dic[Variable] = Value;
            }
            else
            {
                string[] strs = Value.Split('.');
                string actionName = strs[0].TrimStart('$');
                string propertyName = strs[1];
                
                Action action = GetActionFromContainer(actionName);
                dic[Variable] = GetPropertyValue(propertyName, action);
            }
            this.Value = "hell.";
            Console.WriteLine("value:"+this.value);
        }

        private Action GetActionFromContainer(string actionName)
        {
            Action container = this.Container;
            Action action = null;
            while (container != null)
            {
                if(!container.NamedActions.ContainsKey(actionName))
                {
                    container = container.Container;
                    continue;
                }
                action = container.NamedActions[actionName];
                break;
            }

            return action;
        }

        private new object GetPropertyValue(PropertyInfo pi, object obj)
        {
            return pi.GetValue(obj, null);
        }

        private new object GetPropertyValue(string propertyName, object obj)
        {
            Type type = obj.GetType();
            PropertyInfo pi = type.GetProperty(propertyName);
            return GetPropertyValue(pi, obj);
        }
    }
}
