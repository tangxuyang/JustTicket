using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    public abstract class Action
    {
        public abstract void Execute();

        protected string xml;

        private ActionContainer container;

        public ActionContainer Container
        {
            get
            {
                return container;
            }
            set
            {
                container = value;
            }
        }

        [Default(DefaultValue="")]
        public string Name
        {
            get;
            set;
        }

        public virtual void Init(string xml)
        {
            this.xml = xml;
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            XmlElement ele = doc.FirstChild as XmlElement;

            //Only Property
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(pro=>!IsExcludeProproty(pro)).ToArray();
            string propertyName;
            XmlNode node;
            foreach(var pro in properties)
            {
                propertyName = pro.Name;
                node = ele.SelectSingleNode(propertyName);
                if (node == null)
                {
                    var attr = ele.Attributes[propertyName];
                    if (attr == null)
                    {
                        var v = pro.GetCustomAttributes(typeof(DefaultAttribute), false);
                        if (v != null && v.Length > 0)
                        {
                            SetPropertyValue(pro, this, ((DefaultAttribute)v[0]).DefaultValue);
                        }
                        else
                        {
                            throw new Exception(propertyName + " not in the xml");
                        }
                    }
                    else
                    {
                        SetPropertyValue(pro, this, attr.Value);
                    }

                    //var v = pro.GetCustomAttributes(typeof(DefaultAttribute),false);
                    //if(v!=null && v.Length>0)
                    //{
                    //    SetPropertyValue(pro, this, ((DefaultAttribute)v[0]).DefaultValue);
                    //}
                    //else
                    //{
                    //    var attr = ele.Attributes[propertyName];
                    //    if (attr == null)
                    //    {
                    //        throw new Exception(propertyName + " not in the xml");
                    //    }
                    //    else
                    //    {
                    //        SetPropertyValue(pro, this, attr.Value);
                    //    }
                    //}
                }
                else
                {
                    SetPropertyValue(pro, this, node.InnerText);
                }
            }
        }

        protected bool IsExcludeProproty(PropertyInfo pi)
        {
            int count = pi.GetCustomAttributes(false).Where(obj => obj is IgnoreAttribute).ToList().Count;
            bool complexNonString = !pi.PropertyType.IsPrimitive && pi.PropertyType != typeof(string);
            return  count> 0 || complexNonString ;
        }

        protected void SetPropertyValue(PropertyInfo pi, object obj, object value)
        {
            value = Container.Variables.Resolve(value.ToString());
            object o = value;
            if(pi.PropertyType.IsEnum)
            {
                o = Enum.Parse(pi.DeclaringType, value.ToString());
            }
            
            if(pi.PropertyType.Name == "Int32")
            {
                o = Int32.Parse(value.ToString());
            }
            
            if(pi.PropertyType.Name == "Boolean")
            {
                o = bool.Parse(value.ToString());
            }
            
            pi.SetValue(obj, o, null);
        }

        protected object GetPropertyValue(PropertyInfo pi, object obj)
        {
            return pi.GetValue(obj, null);
        }

        protected object GetPropertyValue(string propertyName, object obj)
        {
            Type type = this.GetType();
            PropertyInfo pi = type.GetProperty(propertyName);
            return GetPropertyValue(pi, obj);
        }
    }
}
