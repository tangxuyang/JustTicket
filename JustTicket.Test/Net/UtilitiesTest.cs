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
    public class UtilitiesTest
    {
        public Stream stream;
        [SetUp]
        public void Setup()
        {
            byte[] buffer = Encoding.Default.GetBytes("JustTicket");
            stream = new MemoryStream(buffer);
        }

        [Test]
        public void GetString()
        {
            string result = Utilities.GetString(stream);
            Assert.AreEqual("JustTicket", result);
        }

        [Test]
        public void SaveAsFile()
        {
            if(File.Exists("test.txt"))
            {
                File.Delete("test.txt");
            }

            Utilities.SaveAsFile(stream, "test.txt");
            Assert.IsTrue(File.Exists("test.txt"));
            FileStream fs = new FileStream("test.txt",FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string result = sr.ReadToEnd();
            Assert.AreEqual("JustTicket", result);
        }
    }
}
