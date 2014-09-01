using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    public class StringReplaceAction : Action
    {
        public string SourceString
        {
            get;
            set;
        }
        public string OldString
        {
            get;
            set;
        }

        public string NewString
        {
            get;
            set;
        }

        [Ignore]
        public string ResultString
        {
            get;
            set;
        }
            

        public override void Execute()
        {
            base.Execute();
            ResultString = SourceString.Replace(OldString, NewString);
        }
    }
}
