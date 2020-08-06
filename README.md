"# EasyTemplateEmail" 
 

 
 ### Sample code to send email.
 
 ###       construct EmailData object 
            var emailData = new EmailData();
            //host: host smtp address
            //port
            //network credential to access smtp server
            // secure channel: true
            emailData.EmailConfiguration = new EmailConfiguration("smtp.live.com", 587, new NetworkCredential("userid", "password"),true);
            emailData.Subject = "Order Submitted";
            //path of attachment document
            emailData.Attachments.Add(_env.ContentRootPath + "\\EmailTemplate\\testdoc.pdf");
            emailData.ToReceivers.Add("someone@gmail.com");
            //emailData.CcReceivers
            //emailData.BccReceiver
            emailData.SenderEmail = "sender@outlook.com";
            //add template variables and its values
            emailData.TemplateData.Add("@ToName", "Ramesh");
            emailData.TemplateData.Add("@SenderName", "Dinesh");
            // html template
            emailData.TemplateFullName = _env.ContentRootPath + "\\EmailTemplate\\Thanks.html";
            
            _emailManager = new EmailManager(emailData);

            await _emailManager.SendEmail();
 
            
