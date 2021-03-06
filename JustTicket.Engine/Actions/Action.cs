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
            //Init();
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

        private Dictionary<string, PropertyResolver> expression;
        [Ignore]
        public Dictionary<string, PropertyResolver> Expression
        {
            get
            {
                if(expression == null)
                {
                    expression = new Dictionary<string, PropertyResolver>();
                }
                return expression;
            }
            set
            {
                expression = value;
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

        private string name;
        
        [Default(DefaultValue="")]
        public string Name
        {
            get
            {
                return GetPropertyValue<string>("Name", this);
            }
            set
            {
                name = value;
            }
        }

        public void Init(string xml)
        {
            this.xml = xml;
            Init();
        }
       
        protected virtual void Init()
        {
            XmlElement ele = GetRootNode(xml) as XmlElement;

            //Only Property
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(pro=>!IsExcludedProproty(pro)).ToArray();

            PropertyInfo[] attributeProperties = properties.Where(pro => !IsElementProperty(pro)).ToArray();
            PropertyInfo[] elementProperties = properties.Where(pro => IsElementProperty(pro)).ToArray();

            string propertyName;
            XmlNode node;
            string val;
            //解析Xml元素属性表示的对象属性
            foreach(var pro in attributeProperties)
            {
                propertyName = pro.Name;
                var attr = ele.Attributes[propertyName];
                if(attr == null)
                {
                    var v = pro.GetCustomAttributes(typeof(DefaultAttribute), false);
                    if (v != null && v.Length > 0)
                    {
                        val = ((DefaultAttribute)v[0]).DefaultValue.ToString();
                        SetPropertyValue(pro, this, ((DefaultAttribute)v[0]).DefaultValue);
                    }
                    else
                    {
                        throw new Exception(propertyName + " not in the xml");
                    }
                }
                else
                {
                    val = attr.Value;
                    //SetPropertyValue(pro, this, attr.Value);
                }
                Expression.Add(propertyName, new PropertyResolver() { Action = this, PropertyInfo = pro, OrginalExpress = val });
            }

            //解析Xml元素表示的对象属性
            foreach(var pro in elementProperties)
            {
                propertyName = pro.Name;
                node = ele.SelectSingleNode(propertyName);
                if(node == null)
                {
                    var v = pro.GetCustomAttributes(typeof(DefaultAttribute), false);
                    if (v != null && v.Length > 0)
                    {
                        val = ((DefaultAttribute)v[0]).DefaultValue.ToString();
                        SetPropertyValue(pro, this, ((DefaultAttribute)v[0]).DefaultValue);
                    }
                    else
                    {
                        throw new Exception(propertyName + " not in the xml");
                    }
                }
                else
                {
                    val = node.InnerText;
                    //SetPropertyValue(pro, this, node.InnerText);
                }

                Expression.Add(propertyName, new PropertyResolver() {Action = this, PropertyInfo = pro, OrginalExpress= val });
            }

            //如果这个Action有名字，则把其加入它的父容器的NameActions集合中
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

        /// <summary>
        /// 判断这个属性是否要使用Xml赋值
        /// 标注了IgnoreAttribute的或基础类型与string之外的属性都是排除的
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        protected bool IsExcludedProproty(PropertyInfo pi)
        {
            //int count = pi.GetCustomAttributes(true).Where(obj => obj is IgnoreAttribute).ToList().Count;
            bool complexNonString = !pi.PropertyType.IsPrimitive && pi.PropertyType != typeof(string);
            return  HasAttribute<IgnoreAttribute>(pi) || complexNonString ;
        }

        /// <summary>
        /// 判断是否是一个用Xml的元素赋值的属性
        /// 标注ElementAttribute的，如果没有默认是使用Xml的属性赋值的
        /// </summary>
        /// <param name="pi"></param>
        /// <returns></returns>
        protected bool IsElementProperty(PropertyInfo pi)
        {
            //return pi.GetCustomAttributes(true).ToList().Exists(attr => attr is ElementAttribute);
            return HasAttribute<ElementAttribute>(pi);
        }

        protected bool HasAttribute<T>(PropertyInfo pi)where T :Attribute
        {
            return pi.GetCustomAttributes(true).ToList().Exists(attr => attr is T);
        }

        protected void SetPropertyValue(PropertyInfo pi, object obj, object value)
        {
            string result = value.ToString();
            //string result = expression[pi.Name].Calculate();
            //object o = Container.Variables.Resolve(Container, value.ToString());
            object o = result;
            if (pi.PropertyType.IsEnum)
            {
                o = Enum.Parse(pi.DeclaringType, result);
            }

            if (pi.PropertyType.Name == "Int32")
            {
                o = Int32.Parse(result);
            }

            if (pi.PropertyType.Name == "Boolean")
            {
                o = bool.Parse(result);
            }

            pi.SetValue(obj, o, null);
        }

        protected object GetPropertyValue(PropertyInfo pi, object obj)
        {
            //return pi.GetValue(obj, null);
            string result = expression[pi.Name].Calculate();
            return result;
        }

        protected T GetPropertyValue<T>(string propertyName, object obj)
        {
            Type type = this.GetType();
            PropertyInfo pi = type.GetProperty(propertyName);
            string result = GetPropertyValue(pi,obj).ToString();

            T t = default(T);

            if (pi.PropertyType.IsEnum)
            {
                t = (T)Enum.Parse(pi.DeclaringType, result);
            }
            else
            if (pi.PropertyType.Name == "Int32")
            {
                object o = Int32.Parse(result);//有装箱
                t =(T) o;
            }
            else
            if (pi.PropertyType.Name == "Boolean")
            {
                object o = bool.Parse(result);
                t =(T) o;
            }
            else
            {
                t = (T)((object)result);
            }
            
            return t;
        }

        protected XmlNode GetRootNode(string xml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.FirstChild;
        }
    }
}
