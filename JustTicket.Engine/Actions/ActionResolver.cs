using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining
{
    /// <summary>
    /// Action解析器
    /// </summary>
    public class ActionResolver
    {
        static List<Type> actions = new List<Type>();
        static ActionResolver()
        {
            var acts = Assembly.GetExecutingAssembly().GetTypes().Where(t => typeof(JustTicket.Engining.Actions.Action).IsAssignableFrom(t)&&!t.IsAbstract);
            foreach (var action in acts)
            {
                actions.Add(action);
            }
        }

        /// <summary>
        /// 根据action名称跟所属命名空间获取Action对象
        /// </summary>
        /// <param name="actionName">action名称</param>
        /// <param name="ns">命名空间</param>
        /// <returns></returns>
        public static JustTicket.Engining.Actions.Action ResolveAction(string actionName, string ns)
        {
            string localActionName, localNS;
            localActionName = (actionName + "Action").ToLower();
            localNS = ns==null?null:ns.ToLower();

            var types = actions.Where(t => (t.Name.ToLower() == localActionName || GetActionMapping(t).ToLower().Contains(localActionName)) && (string.IsNullOrEmpty(localNS) || t.Namespace.ToLower() == localNS)).ToList();
            if (types == null)
                return null;

            if (types.Count > 1)
                throw new Exception("Ambigunous action "+actionName);

            JustTicket.Engining.Actions.Action action = Activator.CreateInstance(types[0]) as JustTicket.Engining.Actions.Action;

            return action;
        }

        private static string GetActionMapping(Type type)
        {
            var attrs = type.GetCustomAttributes(typeof(MapAttribute), false);
            string retStr = "";
            if(attrs!=null && attrs.Length>0)
            {
                foreach(MapAttribute v in attrs)
                {
                    retStr += v.AliasName+ "|";
                }
            }
            return retStr;
        }
    }
}
