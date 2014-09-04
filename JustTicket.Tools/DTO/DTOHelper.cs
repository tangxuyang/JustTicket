using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    public class DTOHelper
    {
        /// <summary>
        /// 从str构造出T类型的DTO的List
        /// 只能解析这样的格式[{},{},{}]，且每个DTO对象没有复杂类型的成员字段
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        [Obsolete("使用json.net")]
        public static List<T> GetDTOs<T>(string str) where T : DTO
        {
            //[{},{},{}]
            List<T> list = new List<T>();
            str = str.Trim('[', ']');
            string[] strs = str.Split(new string[]{"},"}, StringSplitOptions.None);
            foreach (var s in strs)
            {
                if (string.IsNullOrEmpty(s))
                    continue;

                T t = Activator.CreateInstance(typeof(T), s.Trim('{', '}')) as T;
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 从str中构造T类型的DTO的List
        /// 可以取出{}中的字段作为DTO
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static List<T> GetDTOPartialInArrayItem<T>(string str, string fieldName) where T :DTO
        {
            //[{part:{},...},{part:{},...},{part:{},...}]
            //
            List<T> list = new List<T>();
            int index = 0;
            int left, right, length;
            string queryLeftNewDTOStr;
            
            while ((index = str.IndexOf(fieldName, index)) > -1)
            {
                left = str.IndexOf("{", index);
                right = str.IndexOf("}", index) - 1;
                length = right - left;
                queryLeftNewDTOStr = str.Substring(left + 1, length);
                T dto = Activator.CreateInstance(typeof(T), queryLeftNewDTOStr) as T;
                index = right;
                list.Add(dto);
            }

            return list;
        }
    }
}
