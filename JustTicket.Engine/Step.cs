using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Logic;
using JustTicket.Engining.Attributes;

namespace JustTicket.Engining
{
    [Obsolete("与Engine一起废弃")]
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
}
