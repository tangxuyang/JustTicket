﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;

namespace JustTicket.Logic
{
    public class RequestBlockParameter
    {
        #region Fields
        /// <summary>
        /// 请求的方式当前有Get和Post
        /// </summary>
        private string method;

        /// <summary>
        /// 请求的地址
        /// </summary>
        private string url;

        /// <summary>
        /// 请求返回的类型当前有字符串，文件名，和流
        /// </summary>
        private RequestBlockReturnType returnType;

        /// <summary>
        /// 请求体，用于Method为Post时
        /// </summary>
        private string requestBody;

        /// <summary>
        /// 连接体，负责底层请求发送
        /// </summary>
        private ICommunicator communicator;

        /// <summary>
        /// 文件名，用于ReturnType为File
        /// </summary>
        private string fileName;

        #endregion

        #region Properties
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
        #endregion
    }
}
