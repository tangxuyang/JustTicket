using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;
using JustTicket.Engining;

namespace JustTicket.Engining.Actions
{
    /// <summary>
    /// just for test
    /// </summary>
    public class ConsoleOutputAction : Action
    {
        public string Text { get; set; }

        public override void Execute()
        {
            base.Execute();
            Console.WriteLine(Container.Variables.Resolve(Container, Text));
            //if (ResultStack.Instance.Stack.Count>0)
            //    Console.WriteLine(ResultStack.Instance.Stack.Pop());
        }
    }
}
