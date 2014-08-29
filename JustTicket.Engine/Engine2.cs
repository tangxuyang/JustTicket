using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace JustTicket.Engining
{
    public class Engine2 : IEngine
    {
        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }

        public void Execute()
        {
            if (!File.Exists(FileName))
                throw new Exception("Xml is not found!");

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlElement root = doc.DocumentElement as XmlElement;

            foreach(XmlNode node in root.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Comment || node.NodeType == XmlNodeType.CDATA)
                    continue;
                JustTicket.Engining.Actions.Action action = ActionResolver.ResolveAction(node.Name,null);
                action.Init(node.OuterXml);
                action.Execute();
            }

        }
    }
}
