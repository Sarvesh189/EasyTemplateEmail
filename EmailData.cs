using System.Collections.Generic;
using System.Net;

namespace EasyTemplateEmail
{
    public class EmailData
    {
     
        public EmailConfiguration EmailConfiguration { get; set; }
        public Dictionary<string, string> TemplateData { get; } = new Dictionary<string, string>();
        public string TemplateFullName { get; set; }
        public List<string> ToReceivers { get; } = new List<string>();
        public List<string> CcReceivers { get; } = new List<string>();

        public List<string> BccReceivers { get; } = new List<string>();

        public List<string> Attachments { get; } = new List<string>();

        public string Subject { get; set; }
        public string SenderEmail { get; set; }

    }  
}