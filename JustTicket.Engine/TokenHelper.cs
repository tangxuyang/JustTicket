using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining
{
    public class TokenHelper
    {
        public static List<string> GetToken(string str, char beginChar, char endChar)
        {
            List<string> tokens = new List<string>();
            string temp = "";
            foreach (var v in str)
            {
                if (v == endChar)
                {
                    tokens.Add(temp);                   
                    continue;
                }
                if (v == beginChar)
                {
                    temp = "";
                    continue;
                }
                temp += v;
            }

            return tokens;
        }

        public static List<string> GetToken(string str, char ch)
        {
            bool start = false;
            string temp = "";
            List<string> tokens = new List<string>();

            foreach(var v in str)
            {
                if(v == ch)
                {
                    if (start)
                    {
                        tokens.Add(temp);
                        temp = "";
                    }
                    else
                    {
                        start = true;
                    }
                    
                    continue;
                }

                if(start)
                    temp += v;
            }

            return tokens;
        }
    }
}
