"# EasyTemplateEmail" 
 

 
 # Sample code to send email.
 
 ##       construct EmailData object 
            var emailData = new EmailData();
            emailData.EmailConfiguration = new EmailConfiguration("smtp.live.com", 587, new NetworkCredential("userid", "password"),true);
            emailData.Subject = "Order Submitted";
            emailData.Attachments.Add(_env.ContentRootPath + "\\EmailTemplate\\testdoc.pdf");
            emailData.ToReceivers.Add("someone@gmail.com");
            //emailData.CcReceivers
            //emailData.BccReceiver
            emailData.SenderEmail = "sender@outlook.com";

            emailData.TemplateData.Add("@ToName", "Ramesh");
            emailData.TemplateData.Add("@SenderName", "Dinesh");
            
            emailData.TemplateFullName = _env.ContentRootPath + "\\EmailTemplate\\Thanks.html";
            
            _emailManager = new EmailManager(emailData);

            await _emailManager.SendEmail();
 
            
