using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;
using JustTicket.Logic;
using JustTicket.Net;

namespace JustTicket.Engining.Actions
{
    public class DownFileAction : Action
    {
        public string FileName
        { set; get; }

        [Default(DefaultValue="Get")]
        public string Method
        { get; set; }

        public string Url
        {
            get;
            set;
        }

        [Default(DefaultValue="")]
        public string RequestBody
        { get; set; }

        public bool RandomFileName
        {
            get;
            set;
        }
        public override void Execute()
        {
            RequestBlockParameter rbp = new RequestBlockParameter();
            rbp.Communicator = new HttpCommunicator();
            rbp.FileName = FileName;
            if(RandomFileName)
            {
                rbp.FileName = DateTime.Now.Ticks + FileName;
            }

            rbp.Method = Method;
            rbp.RequestBody = RequestBody;
            rbp.ReturnType = RequestBlockReturnType.FileName;
            rbp.Url = Url;

            RequestBlock rb = new RequestBlock();
            ResultStack.Instance.Stack.Push( rb.Process(rbp));
        }
    }
}
