using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JustTicket.Net
{
    /// <summary>
    /// 连接体接口，负责通信
    /// </summary>
    public interface ICommunicator
    {
        Stream SendRequest(string requestUrl);
        string Method { get; set; }
        string RequestBody { get; set; }
    }
}
