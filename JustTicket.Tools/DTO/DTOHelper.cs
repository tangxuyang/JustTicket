﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustTicket.Tools.DTO
{
    public class DTOHelper
    {
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
