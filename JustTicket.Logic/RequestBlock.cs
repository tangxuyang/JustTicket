﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;

namespace JustTicket.Logic
{
    /// <summary>
    /// 请求Block
    /// </summary>
    public class RequestBlock : Block
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">RequestBlockParameter类型对象</param>
        /// <returns></returns>
        public override object Process(object obj)
        {
            RequestBlockParameter parameter = obj as RequestBlockParameter;
            if(parameter == null)
                throw new Exception("Parameter invalid!!");

            parameter.Communicator.Method = parameter.Method;
            parameter.Communicator.RequestBody = parameter.RequestBody;

            object retObject = null;
            switch (parameter.ReturnType)
            {
                case RequestBlockReturnType.FileName:
                    if (string.IsNullOrEmpty(parameter.FileName))
                        throw new Exception("FileName is empty");
                    retObject = Utilities.SaveAsFile(parameter.Communicator.SendRequest(parameter.Url), parameter.FileName);                    break;
                case  RequestBlockReturnType.Stream:
                    retObject = parameter.Communicator.SendRequest(parameter.Url);
                    break;
                case RequestBlockReturnType.String:
                    retObject = Utilities.GetString(parameter.Communicator.SendRequest(parameter.Url));
                    break;
            }
            return retObject;
        }

        public override BlockType BlockType
        {
            get
            {
                return BlockType.RequestBlock;
            }
        }
    }
}
