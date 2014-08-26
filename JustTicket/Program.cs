using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;
using JustTicket.Logic;
using JustTicket.Engining;
using System.Diagnostics;

namespace JustTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            TestToXml();

            Console.ReadLine();
        }

        static void TestEngine(string fileName)
        {
            Engine en = new Engine(fileName);
            en.Execute();
        }

        /// <summary>
        /// 测试比较ToXml和ToXml2的性能
        /// </summary>
        static void TestToXml()
        {
            
            Step step = new Step();
            step.BlockType = BlockType.RequestBlock;
            step.FileName = "filename.txt";
            step.Method = "GET";
            step.ReturnType = RequestBlockReturnType.String;
            step.Url = "http://ctrip.com";

            int n = 500000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                XmlReader.ToXml<Step>(step);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds/1000.0);

            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                XmlReader.ToXml2<Step>(step);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds / 1000.0);

        }

        /// <summary>
        /// 
        /// </summary>
        static void TestReadXml()
        {
            var list = XmlReader.ReadXml("..\\..\\Flow.xml");

            HttpCommunicator com = new HttpCommunicator();
            RequestBlockParameter bp = new RequestBlockParameter();
            bp.Communicator = com;

            foreach (var v in list)
            {
                bp.Method = v.Method;
                bp.FileName = v.FileName;
                bp.ReturnType = v.ReturnType;
                bp.Url = v.Url;
                Block block = new RequestBlock();
                object retVal = block.Process(bp);
                if (retVal is System.IO.Stream)
                    continue;
                else
                    Console.WriteLine(retVal);
            }

        }

        /// <summary>
        /// 登录到12306
        /// </summary>
        static void Login()
        {
            HttpCommunicator com = new HttpCommunicator();
             
            while (true)
            {
                string fileName = "test" + DateTime.Now.Ticks + ".png";
                
                //获取验证码
                Block verificationCodeBlock = new RequestBlock();
                RequestBlockParameter bp = new RequestBlockParameter();
                bp.Method = "GET";
                bp.FileName = fileName;
                bp.ReturnType = RequestBlockReturnType.FileName;
                bp.Url = Strings.VerificationCodeUrl;
                bp.Communicator = com;
                fileName = verificationCodeBlock.Process(bp) as string;

                Console.WriteLine(fileName);
                Console.WriteLine("According the verification code, input it");
                string verificationCode = Console.ReadLine();

                
                string parameter = "loginUserDTO.user_name=txyzqc&userDTO.password=1qaz2wsx&randCode=" + verificationCode;

                //登录
                bp.Method = "POST";
                bp.ReturnType = RequestBlockReturnType.String;
                bp.RequestBody = parameter;
                bp.Url = Strings.LoginUrl;
                Block loginBlock = new RequestBlock();
                string result = loginBlock.Process(bp) as string;

                 
                Console.WriteLine(result);

            }
        }
    }
}
