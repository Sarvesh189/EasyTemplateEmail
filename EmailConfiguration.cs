using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EasyTemplateEmail
{
    public class EmailConfiguration
    {
        public string Host { get; }
        public int Port { get;  }

        public NetworkCredential NetworkCredential { get;  }

        public bool IsHtmlEmailBody { get; }

        public bool IsSecureChannel { get;}

        

        public EmailConfiguration(string host, int port, NetworkCredential networkCredential, bool isSecureChannel,bool isHtmlEmailBody)
        {
            Host = host;
            Port = port;
            NetworkCredential = networkCredential;
            IsSecureChannel = isSecureChannel;
            IsHtmlEmailBody = isHtmlEmailBody;
        }
    }
}
