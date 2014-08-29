﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace JustTicket.Engining
{
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

        public static JustTicket.Engining.Actions.Action ResolveAction(string actionName, string ns)
        {
            Type type = actions.First(t => t.Name.ToLower() == (actionName+"Action").ToLower() && (string.IsNullOrEmpty(ns) ||t.Namespace.ToLower() == ns.ToLower()));
            if (type == null)
                return null;

            JustTicket.Engining.Actions.Action action = Activator.CreateInstance(type) as JustTicket.Engining.Actions.Action;

            return action;
        }
    }
}
