using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining
{
    class GlobalVariables
    {
        public static Dictionary<string, object> Variables;
        static GlobalVariables()
        {
            Variables = new Dictionary<string, object>();
        }

        public static string Resolve(string str)
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
