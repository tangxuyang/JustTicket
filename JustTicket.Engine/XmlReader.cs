using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining
{
    /// <summary>
    /// 解析JustTicket的Xml文件，为Engine提供数据源
    /// 理想情况是想把这个类写成一个功能强大的组件，
    /// 用来解析JustTicket的流程文件。
    /// </summary>
    [Obsolete("与Engine一起废弃")]
    public class XmlReader
    {
        /// <summary>
        /// 读取文件，解析出流程步
        /// </summary>
        /// <param name="fileName">流程文件名称</param>
        /// <returns></returns>
        public static List<Step> ReadXml(string fileName)
        {
            XmlDocument document = new XmlDocument();
            document.Load(fileName);
            var steps = document.SelectNodes("/Steps/Step");
            List<Step> retVal = new List<Step>();

            Type type = typeof(Step);
            PropertyInfo[] properties = type.GetProperties();
            properties = properties.Where(pro => pro.GetCustomAttributes(false).Where(c => c is IgnoreAttribute).ToList().Count<1).ToArray();
            XmlNode node;
            
            for (int i =0; i < steps.Count ; i++)
            {
                Step st = new Step ();
                XmlElement step = steps[i] as XmlElement;
                foreach (var pro in properties)
                {
                    node = step.SelectSingleNode(pro.Name);
                    if (node == null)
                    {
                        if (pro.GetCustomAttributes(false).Where(c => c is DefaultAttribute).ToList().Count > 0)
                        {
                            DefaultAttribute d = pro.GetCustomAttributes(typeof(DefaultAttribute), false)[0] as DefaultAttribute;
                            SetPropertyValue(pro, st, d.DefaultValue.ToString(), null);
                                   
                        }
                        else
                        {
                            throw new Exception(string.Format("Step {0} misses child {1}", i, pro.Name));
                        }
                    }
                    else
                    {
                        var attr = node.Attributes["Random"];
                        string text = "";
                        if (attr != null && attr.InnerText.ToLower() =="true")
                            text = Guid.NewGuid().ToString();
                        if (node.InnerText == null)
                        {
                            if (text == "")
                            {
                                if (pro.GetCustomAttributes(false).Where(c => c is DefaultAttribute).ToList().Count > 0)
                                {
                                    DefaultAttribute d = pro.GetCustomAttributes(typeof(DefaultAttribute), false)[0] as DefaultAttribute;
                                    SetPropertyValue(pro, st, d.DefaultValue.ToString(), null);

                                }
                            }
                            else
                            {
                                SetPropertyValue(pro, st, text, null);
                            }
                        }
                        else
                        {
                            if (text == "")
                                SetPropertyValue(pro, st, node.InnerText, null);
                            else
                                SetPropertyValue(pro, st, text + node.InnerText, null);
                        }
                    }
                }
                retVal.Add(st);
            }

            return retVal;
        }

        //ToXml and ToXml2的性能差不多

        public static string ToXml<T>(T obj) where T: class
        {
            StringBuilder stringBuilder = new StringBuilder();

            Type type = obj.GetType();
            string className = type.Name;

            PropertyInfo[] properties = type.GetProperties();
            properties = properties.Where(pro => pro.GetCustomAttributes(false).Where(c => c is IgnoreAttribute).ToList().Count < 1).ToArray();

            stringBuilder.AppendLine("<" + className + ">");
            foreach (var pro in properties)
            {
                if (pro.GetValue(obj, null) == null)
                {
                    stringBuilder.AppendLine(string.Format("<{0}/>", pro.Name));
                }
                else
                {
                    stringBuilder.AppendLine(string.Format("<{0}>{1}</{0}>", pro.Name, pro.GetValue(obj, null)));
                }
            }
            stringBuilder.AppendLine("</" + className + ">");

            return stringBuilder.ToString();
        }

        public static string ToXml2<T>(T obj) where T : class
        {
            Type type = obj.GetType();
            string className = type.Name;

            XmlDocument doc = new XmlDocument();

            XmlElement element = doc.CreateElement(className);

            PropertyInfo[] properties = type.GetProperties();
            properties = properties.Where(pro => pro.GetCustomAttributes(false).Where(c => c is IgnoreAttribute).ToList().Count < 1).ToArray();

            foreach (var pro in properties)
            {
                XmlElement node = doc.CreateElement(pro.Name);
                object value = pro.GetValue(obj, null);
                if (value != null)
                {
                    node.InnerText = value.ToString();
                }
                element.AppendChild(node);
            }
            return element.OuterXml;
        }

        private static void SetPropertyValue(PropertyInfo pro,object obj, string value, object[] index)
        {
            if (pro.PropertyType.IsEnum)
            {
                pro.SetValue(obj, Enum.Parse(pro.PropertyType, value), null);
            }
            else if (pro.PropertyType.Name == "Int32")
            {
                pro.SetValue(obj, Int32.Parse(value), null);
            }
            else
                pro.SetValue(obj, value, null);
        }
    }
}
