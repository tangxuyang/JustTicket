﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JustTicket.Net
{
    public interface ICommunicator
    {
        Stream SendRequest(string requestUrl);
        string Method { get; set; }
        string RequestBody { get; set; }
    }
}
