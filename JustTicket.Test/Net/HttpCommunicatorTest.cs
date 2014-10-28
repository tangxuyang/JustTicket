using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JustTicket.Net;
using System.IO;

namespace JustTicket.Test.Net
{
    [TestFixture]
    public class HttpCommunicatorTest
    {
        [Test]
        public void SendRequest_Get()
        {
            HttpCommunicator httpCommunicator = new HttpCommunicator();
            httpCommunicator.Method = "GET";
            Stream stream=  httpCommunicator.SendRequest("http://www.baidu.com");
            string result = Utilities.GetString(stream);
            Assert.IsTrue(result.Contains("百度首页"));
        }

        [Test]
        public void SendRequest_Post()
        {
            HttpCommunicator httpCommunicator = new HttpCommunicator();
            httpCommunicator.Method = "Post";
            httpCommunicator.RequestBody = "";
            Stream stream = httpCommunicator.SendRequest("http://www.baidu.com");
            string result = Utilities.GetString(stream);
            Assert.IsTrue(result.Contains("www.baidu.com"));
        }
    }
}
