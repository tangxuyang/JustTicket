using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTicket
{
    class LoginResult
    {
        private string validateMessageShowId;
        private bool status;
        private int httpstatus;
        private Dictionary<string, object> data;
        private string[] messages;
        private Dictionary<string,object> validateMessages;

        #region Properties
        public string ValidateMessageShowId
        {
            get
            {
                return validateMessageShowId;
            }
            set
            {
                validateMessageShowId = value;
            }
        }

        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public int HttpStatus
        {
            get
            {
                return httpstatus;
            }
            set
            {
                httpstatus = value;
            }
        }

        public Dictionary<string, object> Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public string[] Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
            }
        }

        public Dictionary<string,object> ValidateMessages
        {
            get
            {
                return validateMessages;
            }
            set
            {
                validateMessages = value;
            }
        }
        #endregion
        /*
         {"validateMessagesShowId":"_validatorMessage","status":true,"httpstatus":200,"data":{"loginCheck":"Y"},"messages":[],"validateMessages":{}}"
         */
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");
            stringBuilder.Append("\"validateMessagesShowId\":\""+validateMessageShowId+"\",");
            stringBuilder.Append("\"status\":"+status+",");
            stringBuilder.Append("\"httpstatus\":"+httpstatus+",");
            stringBuilder.Append("\"data\":{");
            foreach (var v in data)
            {
                stringBuilder.Append("\""+v.Key+"\":\""+v.Value+"\",");
            }
            if (data.Count > 0)
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append("},");
            stringBuilder.Append("\"messages\":[");
            foreach (var v in messages)
            {
                stringBuilder.Append("\""+v+"\",");
            }
            if(messages.Length >0)
            {
                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
            stringBuilder.Append("],");
            stringBuilder.Append("\"validateMesssages\":{");
            foreach (var v in validateMessages)
            {
                stringBuilder.Append("\""+v.Key+"\":\""+v.Value+"\",");
            }
            if(validateMessages.Count>0)
                stringBuilder.Remove(stringBuilder.Length - 1, 1);

            stringBuilder.Append("}");

            stringBuilder.Append("}");
            return stringBuilder.ToString();
        }

        public static LoginResult Parse(string str)
        {


            return null;
        }
    }
}
