using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;
using JustTicket.Logic;

namespace JustTicket.Engining
{
    /// <summary>
    /// 网络通信帮助类
    /// </summary>
    public class NetHelper
    {
        private static HttpCommunicator communicator;

        public static HttpCommunicator Communicator
        {
            get
            {
                if (communicator == null)
                    communicator = new HttpCommunicator();
                return communicator;
            }
            set
            {
                communicator = value;
            }
        }

        public static object SendRequest(string method, string requestBody, RequestBlockReturnType returnType, string url, string fileName)
        {
            RequestBlockParameter rbp = new RequestBlockParameter();
            rbp.Communicator = Communicator;
            rbp.FileName = fileName;

            rbp.Method = method;
            rbp.RequestBody = requestBody;
            rbp.ReturnType = returnType;
            rbp.Url = url;

            RequestBlock rb = new RequestBlock();
            return rb.Process(rbp);
        }

        public static object SendRequest(object param)
        {
            RequestBlock rb = new RequestBlock();
            return rb.Process(param);
        }
    }
}
