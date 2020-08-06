using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EasyTemplateEmail
{
    public interface IEmailManager
    {
     
        Task SendEmail();
    }
    public class EmailManager : IEmailManager
    {
        #region private members
        IEmailSender _emailSender = null;
        IEmailTemplateManager _emailTemplateManager = null;
        EmailData _emailData = null;
        #endregion

       
        public EmailManager(EmailData emailData)
        {
            _emailData = emailData;
            _emailSender = new EmailSender(emailData);
            _emailTemplateManager = new EmailTemplateManager(emailData.TemplateFullName, emailData.TemplateData);
        }
        private async Task<string> ConstructEmailBody()
        {
            return await  _emailTemplateManager.GetEmailTemplate();
           
        }      

        public async Task SendEmail()
        {
            var emailBody =await  ConstructEmailBody();
           await _emailSender.SendEmail(emailBody);
        }
    }
}
