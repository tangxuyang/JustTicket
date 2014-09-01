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

        public string Text
        {
            get;
            set;
        }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine(Text);
            OutputString = Console.ReadLine();
        }
    }
}
