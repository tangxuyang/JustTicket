using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Logic
{
    public abstract class Block
    {
        //private BlockType blockType;
        public abstract BlockType BlockType
        {
            get;
        }

        public abstract object Process(object obj);
    }
}
