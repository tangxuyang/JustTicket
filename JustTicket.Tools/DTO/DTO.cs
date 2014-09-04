using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    /// <summary>
    /// 
    /// </summary>
    [Obsolete("使用json.net")]
    public class DTO
    {
        protected Dictionary<string, string> datas;

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="str"></param>
        public DTO(string str)
        {
            datas = new Dictionary<string,string>();
            Init(str);
        }

        /// <summary>
        /// 通过str构建DTO对象。当前只支持DTO对象总都是简单类型的成员的DTO对象。如果有字段是数组或对象，那么会出现不可以预测的结果
        /// </summary>
        /// <param name="str"></param>
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

        /// <summary>
        /// 取得属性值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        protected string Get(string key)
        {
            if (datas.ContainsKey(key))
                return datas[key];
            else
                return null;
        }
        
        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected void Set(string key,string value)
        {
            if(datas.ContainsKey(key))
                datas[key] = value;
        }
    }
}
