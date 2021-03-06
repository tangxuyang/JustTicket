﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining
{
    /// <summary>
    /// 引擎接口
    /// </summary>
    public interface IEngine
    {
        /// <summary>
        /// 引擎文件
        /// </summary>
        string FileName{get;set;}

        /// <summary>
        /// 解析执行
        /// </summary>
        void Execute();
    }
}
