using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    public class DTO
    {
        protected Dictionary<string, string> datas;

        public DTO(string str)
        {
            datas = new Dictionary<string,string>();
            Init(str);
        }

        protected void Init(string str)
        {
            string[] strs = str.Split(',');
            string temp;
            int index;
            string name,value;
            foreach(var s in strs)
            {
                temp = s.Replace('"',' ');
                index = temp.IndexOf(':');
                name = temp.Substring(0,index).Trim();
                value = temp.Substring(index+1,temp.Length-index-1);
                datas.Add(name, value);
            }
        }

        protected string Get(string key)
        {
            if (datas.ContainsKey(key))
                return datas[key];
            else
                return null;
        }
        
        protected void Set(string key,string value)
        {
            if(datas.ContainsKey(key))
                datas[key] = value;
        }
    }
}
