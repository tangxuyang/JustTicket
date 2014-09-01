using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public string Resolve(string str)
        {
            List<string> tokens = new List<string>();
            string temp="";
            foreach(var v in str)
            {
                if (v == '}')
                {
                    tokens.Add(temp);
                    continue;
                }
                if(v == '{')
                {
                    temp = "";
                    continue;
                }
                temp += v;
            }

            foreach(var t in tokens)
            {
                if (t == "")
                    throw new Exception("empty variable reference");
                if (!Variables.ContainsKey(t))
                    throw new Exception("no variable "+t);
                str = str.Replace("{" + t + "}", Variables[t].ToString());
            }
            return str;
        }
    }
}
