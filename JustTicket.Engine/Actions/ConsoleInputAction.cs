using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining.Actions
{
    public class ConsoleInputAction : Action
    {

        public override void Execute()
        {
            Console.WriteLine("Please input...");
            ResultStack.Instance.Stack.Push( Console.ReadLine());
        }
    }
}
