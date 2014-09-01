using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using JustTicket.Engining;

namespace JustTicket.Engining.Actions
{
    public class GlobalVariablesAction : Action
    {
        protected override void Init()
        {
            base.Init();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

            XmlNode root = doc.FirstChild;
            
            foreach(XmlNode g in root.ChildNodes)
            {
                Container.Variables.Variables.Add(g.Name, g.InnerText);
            }
        }
        public override void Execute()
        {
            base.Execute();
            //throw new NotImplementedException();
        }
    }
}
