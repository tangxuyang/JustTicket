﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    /// <summary>
    /// 动作的基类
    /// </summary>
    public abstract class Action
    {
        public virtual void Execute()
        {
            Init();
        }

        protected string xml;

        private Action container;

        [Ignore]
        public Action Container
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

        private GlobalVariables variables;

        [Ignore]
        public GlobalVariables Variables
        {
            get
            {
                if(variables==null)
                    variables = new GlobalVariables();
                return variables;
            }
            set
            {
                variables = value;
            }

        }

        private Dictionary<string, Action> namedActions;

        private List<Action> childActions;

        [Ignore]
        public Dictionary<string, Action> NamedActions
        {
            get
            {
                if (namedActions == null)
                    namedActions = new Dictionary<string, Action>();
                return namedActions;
            }
            set
            {
                namedActions = value;
            }
        }

        [Ignore]
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

        [Default(DefaultValue="")]
        public string Name
        {
            get;
            set;
        }

        public void Init(string xml)
        {
            this.xml = xml;
        }
       
        protected virtual void Init()
        {
            XmlElement ele = GetRootNode(xml) as XmlElement;

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
                }
                else
                {
                    SetPropertyValue(pro, this, node.InnerText);
                }
            }

            if(!string.IsNullOrEmpty(this.Name) )
            {
                if(!Container.NamedActions.ContainsKey(this.Name))
                    Container.NamedActions.Add(this.Name, this);
                else if(Container.NamedActions[this.Name]!=this)
                {
                    throw new Exception("There shouldn't be same name Action("+this.Name+")");
                }
            }
        }

        protected bool IsExcludeProproty(PropertyInfo pi)
        {
            int count = pi.GetCustomAttributes(true).Where(obj => obj is IgnoreAttribute).ToList().Count;
            bool complexNonString = !pi.PropertyType.IsPrimitive && pi.PropertyType != typeof(string);
            return  count> 0 || complexNonString ;
        }

        protected void SetPropertyValue(PropertyInfo pi, object obj, object value)
        {
            value = Container.Variables.Resolve(Container, value.ToString());
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

        protected XmlNode GetRootNode(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.FirstChild;
        }
    }
}
