using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Logic;

namespace JustTicket.Engining
{
    public class Step
    {
        [Default(DefaultValue="GET")]
        public string Method{get;set;}
        public string Url{get;set;}
        [Default(DefaultValue = BlockType.RequestBlock)]
        public BlockType BlockType { get; set; }
        [Default(DefaultValue = RequestBlockReturnType.String)]
        public RequestBlockReturnType ReturnType { get; set; }
        public string FileName { get; set; }
        [Ignore]
        public object Output { get; set; }

        [Ignore]
        public object Input { get; set; }

        public override string ToString()
        {
            return XmlReader.ToXml<Step>(this);
        }
    }

    /// <summary>
    /// 从XML文件中读取时忽略标有此特性的属性
    /// </summary>
    public class IgnoreAttribute : Attribute
    {

    }

    /// <summary>
    /// 给属性赋默认值
    /// </summary>
    public class DefaultAttribute : Attribute
    {
        public object DefaultValue;
    }


}
