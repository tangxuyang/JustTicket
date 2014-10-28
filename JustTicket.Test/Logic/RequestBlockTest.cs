using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using JustTicket.Logic;
using JustTicket.Net;

namespace JustTicket.Test.Logic
{
    [TestFixture]
    public class RequestBlockTest
    {
        [Test]
        public void Process()
        {
            RequestBlockParameter rbp = new RequestBlockParameter();
            HttpCommunicator communicator = new HttpCommunicator();
            rbp.Communicator = communicator;

            rbp.Method = "Get";
            rbp.ReturnType = RequestBlockReturnType.String;
            rbp.Url = "http://www.baidu.com";

            RequestBlock rb = new RequestBlock();
            string result = rb.Process(rbp) as string;

            Assert.IsTrue(result.Contains("百度首页"));
        }
    }
}
