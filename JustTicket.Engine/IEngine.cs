using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining
{
    public interface IEngine
    {
        string FileName{get;set;}

        /// <summary>
        /// 解析执行
        /// </summary>
        void Execute();
    }
}
