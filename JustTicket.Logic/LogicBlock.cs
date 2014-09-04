using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Logic
{
    /// <summary>
    /// 逻辑Block
    /// </summary>
    public class LogicBlock : Block
    {

        public override BlockType BlockType
        {
            get
            {
                return BlockType.LogicBlock;
            }
        }

        public override object Process(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
