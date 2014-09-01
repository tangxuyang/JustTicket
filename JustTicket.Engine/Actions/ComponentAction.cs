using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JustTicket.Engining.Actions
{
    public abstract class ComponentAction : Action
    {
        private Dictionary<string, Action> actions;
        private List<Action> childActions;
        public List<Action> ChildActions
        {
            get
            {
                if (childActions == null)
                    childActions = new List<Action>();
                return childActions;
            }
            set
            {
                childActions = value;
            }
        }
        public Dictionary<string,Action> Actions
        {
            get
            {
                if (actions == null)
                    actions = new Dictionary<string, Action>();
                return actions;
            }
            set
            {
                actions = value;
            }
        }
        public override void Init(string xml)
        {
            base.Init(xml);
            GenerateChildActions(xml);
        }

        private void GenerateChildActions(string xml)
        {
            XmlNode node = GetRootNode(xml);
            Action action;
            string ns;
            foreach(XmlNode n in node.ChildNodes)
            {
                ns = null;
                if(n.HasChildNodes)
                {
                    try
                    {
                        ns = n.Attributes["Namespace"].Value;
                    }
                    catch(Exception ex)
                    {

                    }

                    action = ActionResolver.ResolveAction(n.Name, ns);
                    action.Container = this.Container;
                    action.Init(n.OuterXml);
                    ChildActions.Add(action);
                    if(!string.IsNullOrEmpty( action.Name))
                    {
                        Actions.Add(action.Name, action);
                    }
                }
            }
        }

        //public override void Execute()
        //{
        //    //throw new NotImplementedException();
        //}
    }
}
