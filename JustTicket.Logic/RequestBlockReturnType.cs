using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Logic
{
    public enum RequestBlockReturnType
    {
        String,//返回值为字符串
        Stream,//返回流
        FileName//返回文件名（保存为文件）
    }
}
