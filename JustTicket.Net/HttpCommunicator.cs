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
    public class HttpCommunicator : ICommunicator
    {
        #region Fields
        HttpWebRequest request;
        HttpWebResponse response;
        string method = "GET";
        string requestBody;
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
        public static void Test()
        {
            HttpCommunicator com = new HttpCommunicator();
            Stream stream = com.SendRequest("http://www.baidu.com");
            StreamReader sr = new StreamReader(stream);
            StringBuilder stringBuilder = new StringBuilder();
            while (!sr.EndOfStream)
            {
                stringBuilder.Append(sr.ReadLine());
            }
            Console.WriteLine(stringBuilder.ToString());
            Console.ReadLine();
        }
        static HttpCommunicator()
        {
            ServicePointManager.ServerCertificateValidationCallback +=delegate(object sender,X509Certificate cer,X509Chain chain,SslPolicyErrors sslPolicyErrors){return true;};  
        }

        public HttpCommunicator()
        {
            cookieContainer = new CookieContainer();
        }

        public Stream SendRequest(string requestUrl)
        {
           

            request = WebRequest.Create(requestUrl) as HttpWebRequest;
            request.Method = method;
            request.CookieContainer = cookieContainer;
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
