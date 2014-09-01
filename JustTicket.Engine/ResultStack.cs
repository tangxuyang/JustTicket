using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining
{
    /// <summary>
    /// 结果栈
    /// </summary>
    public class ResultStack
    {
        private Stack<object> stack;
        
        public Stack<object> Stack
        {
            get
            {
                return stack;
            }
        }
        private ResultStack()
        {
            stack = new Stack<object>();
        }

        private static ResultStack resultStack;

        public static ResultStack Instance
        {
            get
            {
                if (resultStack == null)
                    resultStack = new ResultStack();
                return resultStack;
            }
        }

    }
}
