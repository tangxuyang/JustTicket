using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace JustTicket.Net
{
    /// <summary>
    /// 实现Http协议的连接体
    /// </summary>
    public class HttpCommunicator : ICommunicator
    {
        #region Fields
        /// <summary>
        /// HttpWebRequest对象，用于发送请求
        /// </summary>
        HttpWebRequest request;

        /// <summary>
        /// HttpWebResponse对象，响应
        /// </summary>
        HttpWebResponse response;

        /// <summary>
        /// 请求Method
        /// </summary>
        string method = "GET";

        /// <summary>
        /// 请求体，当Post是用
        /// </summary>
        string requestBody;

        /// <summary>
        /// 用于保存通信中的cookie
        /// </summary>
        private CookieContainer cookieContainer;
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
        #endregion

        /// <summary>
        /// 静态构造
        /// </summary>
        static HttpCommunicator()
        {
            //跳过证书验证
            ServicePointManager.ServerCertificateValidationCallback +=delegate(object sender,X509Certificate cer,X509Chain chain,SslPolicyErrors sslPolicyErrors){return true;};  
        }

        /// <summary>
        /// 无参构造
        /// </summary>
        public HttpCommunicator()
        {
            cookieContainer = new CookieContainer();
        }

        /// <summary>
        /// 发送请求到指定地址
        /// </summary>
        /// <param name="requestUrl">请求地址</param>
        /// <returns></returns>
        public Stream SendRequest(string requestUrl)
        {
            request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = method;
            request.CookieContainer = cookieContainer;
            request.ContentLength = 0;
            if (method.ToLower() == "post" && !string.IsNullOrEmpty(requestBody))
            {
                byte[] buffer = Encoding.ASCII.GetBytes(requestBody);
                request.ContentLength = buffer.Length;
                request.ContentType = "application/x-www-form-urlencoded";
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
            }
            response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();

            return stream;
        }
    }
}
