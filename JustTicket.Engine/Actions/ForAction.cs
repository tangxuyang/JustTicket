using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining.Actions
{
    public class ForAction : ComponentAction
    {
        private int iterateCount;
        /// <summary>
        /// 执行的次数
        /// </summary>
        [Default(DefaultValue="1")]
        public int IterateCount
        {
            get
            {
                return GetPropertyValue<int>("IterateCount", this);
            }
            set
            {
                iterateCount = value;
            }
        }
        public override void Execute()
        {
            base.Execute();
            for(int i = 0 ; i < IterateCount; i++)
            {
                foreach (Action action in ChildActions)
                {
                    action.Execute();
                }
                //base.Execute();
            }
        }
    }
}
