﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;
using JustTicket.Logic;

namespace JustTicket.Engining
{
    public class Engine
    {
        private string fileName;//Engine file which is xml format
        public Engine() { }

        public Engine(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// 解析执行
        /// </summary>
        public void Execute()
        {
            var list = XmlReader.ReadXml(fileName);

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
                v.Output = retVal;
                if (retVal is System.IO.Stream)
                    continue;
                else
                    Console.WriteLine(retVal);
            }
        }
    }
}
