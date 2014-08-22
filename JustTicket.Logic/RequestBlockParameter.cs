using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;

namespace JustTicket.Logic
{
    public class RequestBlockParameter
    {
        private string method;
        private string url;
        private RequestBlockReturnType returnType;
        private string requestBody;
        private ICommunicator communicator;
        private string fileName;

        public string Method
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
            }
        }

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }

        public RequestBlockReturnType ReturnType
        {
            get
            {
                return returnType;
            }
            set
            {
                returnType = value;
            }
        }

        public string RequestBody
        {
            get
            {
                return requestBody;
            }
            set
            {
                requestBody = value;
            }
        }

        public ICommunicator Communicator
        {
            get
            {
                return communicator;
            }
            set
            {
                communicator = value;
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }
            set
            {
                fileName = value;
            }
        }
    }
}
