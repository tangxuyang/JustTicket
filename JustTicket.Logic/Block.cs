using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Logic
{
    /// <summary>
    /// Block基类
    /// </summary>
    public abstract class Block
    {
        public abstract BlockType BlockType
        {
            get;
        }

        public abstract object Process(object obj);
    }
}
