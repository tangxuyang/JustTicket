using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using JustTicket.Engining.Actions;

namespace JustTicket.Engining
{
    public class Engine2 : IEngine
    {
        private string fileName;

        /// <summary>
        /// Engine xml file
        /// </summary>
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

        /// <summary>
        /// 分析文件，并执行
        /// </summary>
        public void Execute()
        {
            if (!File.Exists(FileName))
                throw new Exception("Xml file not found!");

            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlElement root = doc.DocumentElement as XmlElement;

            //ActionContainer container = new ActionContainer();
            VirtualAction containerAction = new VirtualAction();
            containerAction.Container = null;
            foreach(XmlNode node in root.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Comment || node.NodeType == XmlNodeType.CDATA)//过滤注释和数据元素
                    continue;
                string ns = null;
                try
                {
                    ns = node.Attributes["Namespace"].Value;
                }
                catch(Exception ex)
                {

                }

                JustTicket.Engining.Actions.Action action = ActionResolver.ResolveAction(node.Name,string.IsNullOrEmpty(ns)?null:ns);
                action.Container = containerAction;
                action.Init(node.OuterXml);
                if(!string.IsNullOrEmpty(action.Name))
                {
                    containerAction.NamedActions.Add(action.Name, action);//保存具有名称的action到Dictionary中
                }
                containerAction.ChildActions.Add(action);
                action.Execute();
            }
        }
    }
}
