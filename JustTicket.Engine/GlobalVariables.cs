using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Actions;

namespace JustTicket.Engining
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public class GlobalVariables
    {
        public Dictionary<string, object> Variables;
        
        public GlobalVariables()
        {
            Variables = new Dictionary<string, object>();
        }

        /// <summary>
        /// 解析指定字符串，如果引用的是全局变量，则返回全局变量的值，否则返回原值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Resolve(JustTicket.Engining.Actions.Action action, string str)
        {
            //List<string> tokens = new List<string>();
            //string temp="";
            //foreach(var v in str)
            //{
            //    if (v == '}')
            //    {
            //        tokens.Add(temp);
            //        continue;
            //    }
            //    if(v == '{')
            //    {
            //        temp = "";
            //        continue;
            //    }
            //    temp += v;
            //}
            List<string> tokens = TokenHelper.GetToken(str, '{', '}');

            
            foreach(var t in tokens)
            {
                if (t == "")
                {
                    break;
                 //   throw new Exception("empty variable reference");
                }
                GlobalVariables variable;
                JustTicket.Engining.Actions.Action container = action;
                string val=null;
                while(container!=null)
                {
                    variable = container.Variables;
                    if(variable.Variables.ContainsKey(t))
                    {
                        //str = str.Replace("{" + t + "}", variable.Variables[t].ToString());
                        val = variable.Variables[t].ToString();
                        break;
                    }
                    else
                    {
                        container = container.Container;
                    }
                }
                if (val == null)
                {
                 //   throw new Exception("no variable " + t);
                }
                else
                    str = str.Replace("{" + t + "}", val);
            }
            return str;
        }
    }
}
