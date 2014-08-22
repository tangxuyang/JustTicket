using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Logic
{
    public abstract class Block
    {
        private BlockType blockType;
        public BlockType BlockType
        {
            get
            {
                return blockType;
            }
            set
            {
                blockType = value;
            }
        }

        public abstract object Process(object obj);
    }
}
