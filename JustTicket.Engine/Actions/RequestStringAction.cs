using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;
using JustTicket.Logic;

namespace JustTicket.Engining.Actions
{
    public class RequestStringAction : Action
    {
        [Default(DefaultValue = "Get")]
        public string Method
        { get; set; }

        public string Url
        {
            get;
            set;
        }

        [Default(DefaultValue = "")]
        public string RequestBody
        { get; set; }

        [Ignore]
        public string Result
        {
            get;
            set;
        }

        public override void Execute()
        {
            base.Execute();

            Result = NetHelper.SendRequest(Method, RequestBody, RequestBlockReturnType.String, Url, null) as string;
        }
    }
}
