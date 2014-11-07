using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    public class ConsoleInputAction : Action
    {
        [Ignore]
        public string OutputString
        {
            get;
            set;
        }

        private string text;

        [Element]
        public string Text
        {
            get
            {
                return GetPropertyValue<string>("Text", this);
            }
            set
            {
                text = value;
            }
        }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine(Text);
            OutputString = Console.ReadLine();
        }
    }
}
