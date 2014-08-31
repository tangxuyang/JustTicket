using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustTicket.Net;
using JustTicket.Logic;

namespace JustTicket.Engining.Actions
{
    public class ActionContainer
    {
        private Dictionary<string,Action> actions;
        private HttpCommunicator communicator;
        private GlobalVariables variables;
        private List<Action> allActions;

        public Dictionary<string, Action> Actions
        {
            get
            {
                if (actions == null)
                    actions = new Dictionary<string, Action>();
                return actions;
            }
            set
            {
                actions = value;
            }
        }

        public List<Action> AllActions
        {
            get
            {
                if (allActions == null)
                    allActions = new List<Action>();
                return allActions;
            }
            set
            {
                allActions = value;
            }
        }

        public HttpCommunicator Communicator
        {
            get
            {
                if (communicator == null)
                    communicator = new HttpCommunicator();
                return communicator;
            }
            set
            {
                communicator = value;
            }
        }

        public GlobalVariables Variables
        {
            get
            {
                if (variables == null)
                    variables = new GlobalVariables();
                return variables;
            }
            set
            {
                variables = value;
            }
        }

        public object SendRequest(string method, string requestBody, RequestBlockReturnType returnType, string url, string fileName)
        {
            RequestBlockParameter rbp = new RequestBlockParameter();
            rbp.Communicator = Communicator;
            rbp.FileName = fileName;
            
            rbp.Method = method;
            rbp.RequestBody = requestBody;
            rbp.ReturnType = returnType;
            rbp.Url = url;

            RequestBlock rb = new RequestBlock();
            return rb.Process(rbp);
        }

        public object SendRequest(object param)
        {
            RequestBlock rb = new RequestBlock();
            return rb.Process(param);
        }
    }
}
