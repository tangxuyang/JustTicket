using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JustTicket.Engining.Actions
{
    public class AssignmentAction : Action
    {
        public string Variable 
        { 
            get; 
            set; 
        }

        public string Value
        {
            get;
            set;
        }

        public override void Execute()
        {
            //throw new NotImplementedException();
            if (!Container.Variables.Variables.ContainsKey(Variable))
                throw new Exception("No variale found");

            if (!Value.Contains("$"))
            {
                Container.Variables.Variables[Variable] = Value;
            }
            else
            {
                string[] strs = Value.Split('.');
                string actionName = strs[0].TrimStart('$');
                string propertyName = strs[1];
                Action action = Container.Actions[actionName];
                Container.Variables.Variables[Variable] = GetPropertyValue(propertyName, action);
            }
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
