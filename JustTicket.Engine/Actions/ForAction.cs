using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    public class ForAction : ComponentAction
    {
        [Default(DefaultValue="1")]
        public int IterateCount
        {
            get;
            set;
        }
        public override void Execute()
        {
            //throw new NotImplementedException();
            for(int i = 0 ; i < IterateCount; i++)
            {
                foreach(Action action in ChildActions)
                {
                    action.Execute();
                }
            }
        }
    }
}
