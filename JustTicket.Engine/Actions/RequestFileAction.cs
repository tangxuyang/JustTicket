using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;
using JustTicket.Logic;
using JustTicket.Net;

namespace JustTicket.Engining.Actions
{
    [Map(AliasName="DownFileAction")]
    public class RequestFileAction : Action
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

        [Default(DefaultValue="false")]
        public bool RandomFileName
        {
            get;
            set;
        }

        [Ignore]
        public string OutputFileName
        {
            get;
            set;
        }

        [Default(DefaultValue = "false")]
        public bool IsDeleteExist
        {
            get;
            set;
        }

        public override void Execute()
        {
            base.Execute();
            string fileName = FileName;
            if(RandomFileName)
            {
                fileName = DateTime.Now.Ticks + fileName;
            }

            if(IsDeleteExist && System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            OutputFileName = NetHelper.SendRequest(Method, RequestBody, RequestBlockReturnType.FileName, Url, fileName) as string;
        }
    }
}
