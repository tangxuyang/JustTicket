using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;
using JustTicket.Logic;

namespace JustTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Login();
            Console.ReadLine();
        }

        static void Login()
        {
            HttpCommunicator com = new HttpCommunicator();
             
            while (true)
            {
                string fileName = "test" + DateTime.Now.Ticks + ".png";
                
                //获取验证码
                Block verificationCodeBlock = new RequestBlock();
                verificationCodeBlock.BlockType = BlockType.RequestBlock;
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
                bp.Method = "POST";
                bp.ReturnType = RequestBlockReturnType.String;
                bp.RequestBody = parameter;
                bp.Url = Strings.LoginUrl;
                Block loginBlock = new RequestBlock();
                loginBlock.BlockType = BlockType.RequestBlock;
                string result = loginBlock.Process(bp) as string;

                 
                Console.WriteLine(result);

            }
        }
    }
}
