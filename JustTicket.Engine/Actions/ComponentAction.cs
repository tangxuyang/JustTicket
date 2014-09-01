using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace JustTicket.Engining.Actions
{
    public abstract class ComponentAction : Action
    {
        protected override void Init()
        {
            base.Init();
            GenerateChildActions(xml);
        }

        private bool IsGenerateChildActions = false;

        private void GenerateChildActions(string xml)
        {
            if (IsGenerateChildActions)
                return;
            IsGenerateChildActions = true;
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
                    action.Container = this;
                    action.Init(n.OuterXml);
                    ChildActions.Add(action);
                    if(!string.IsNullOrEmpty(action.Name))
                    {
                        NamedActions.Add(action.Name, action);
                    }
                }
            }
        }
    }
}
