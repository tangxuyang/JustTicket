using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using JustTicket.Engining;

namespace JustTicket.Engining.Actions
{
    /// <summary>
    /// 如果同一Scope中多个合并，并以最晚那个为准
    /// </summary>
    public class GlobalVariablesAction : Action
    {
        protected override void Init()
        {
            base.Init();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode root = doc.FirstChild;
            
            //Container.Variables.Variables.Clear();

            foreach(XmlNode g in root.ChildNodes)
            {
                if (Container.Variables.Variables.ContainsKey(g.Name))
                {
                    Container.Variables.Variables.Remove(g.Name);
                }
                Container.Variables.Variables.Add(g.Name, g.InnerText);
            }
        }
        public override void Execute()
        {
            base.Execute();
        }
    }
}
