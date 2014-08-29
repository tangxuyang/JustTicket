using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket.Engining.Attributes
{
    /// <summary>
    /// 给属性赋默认值
    /// </summary>
    public class DefaultAttribute : Attribute
    {
        public object DefaultValue;
    }
}
