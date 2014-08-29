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
        public string Text
        {
            get;
            set;
        }

        [Default(DefaultValue="justdev")]
        public string DefaultText
        {
            get;
            set;
        }

        [Ignore]
        public string IgnoreText
        {
            get;
            set;
        }

        public int Age
        { get; set; }
        public override void Execute()
        {
            //Text = "Hello world";
            //Console.WriteLine(Text);
            //Console.WriteLine(DefaultText);
            //Console.WriteLine(IgnoreText);
            //Console.WriteLine(Age);
            if (ResultStack.Instance.Stack.Count>0)
                Console.WriteLine(ResultStack.Instance.Stack.Pop());
        }
    }
}
