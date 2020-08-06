using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EasyTemplateEmail
{
    public interface IEmailTemplateManager
    {
        Task<string> GetEmailTemplate();
    }


    public class EmailTemplateManager: IEmailTemplateManager
    {
        private string templateFullName;
        private Dictionary<string, string> templateData ;

        public EmailTemplateManager(string templateFullName, Dictionary<string, string> templateData)
        {
            this.templateFullName = templateFullName;
            this.templateData = templateData;
        }
        
        public async Task<string> GetEmailTemplate()
        {
            var emailTemplates = File.OpenText(templateFullName);
            StringBuilder str = new StringBuilder(await emailTemplates.ReadToEndAsync());
            var templateName = templateFullName.Substring(templateFullName.LastIndexOf('\\') + 1);
            foreach (var item in templateData)
                str = str.Replace(item.Key, item.Value);
            return str.ToString();
        }
    }
}
