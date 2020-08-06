using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyTemplateEmail
{

    public interface IEmailSender
    {
        Task SendEmail(string emailBody);
    }
   public class EmailSender:IEmailSender
    {
        EmailData _emailData;
        public EmailSender(EmailData emailData)
        {
            _emailData = emailData;
        }
        public async Task SendEmail(string emailBody)
        {
            SmtpClient smtpClient = null;
            try
            {
                smtpClient = new SmtpClient(_emailData.EmailConfiguration.Host);
                smtpClient.Credentials = _emailData.EmailConfiguration.NetworkCredential;
                smtpClient.Port = _emailData.EmailConfiguration.Port;
                smtpClient.EnableSsl = _emailData.EmailConfiguration.IsSecureChannel;
                MailMessage msg = new MailMessage();
                _emailData.ToReceivers.ForEach((to) => { msg.To.Add(to); });
                _emailData.CcReceivers.ForEach((cc) => { msg.CC.Add(cc); });
                msg.From = new MailAddress(_emailData.SenderEmail);
                msg.Subject = _emailData.Subject;
                msg.Body = emailBody;
                msg.IsBodyHtml = _emailData.EmailConfiguration.IsHtmlEmailBody;
                _emailData.Attachments.ForEach((att) => { msg.Attachments.Add(new Attachment(att)); });
                await smtpClient.SendMailAsync(msg);
            }
            finally {
                smtpClient.Dispose();
            } 
        }
    }
}
