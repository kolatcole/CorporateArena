using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Presentation
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync()//List<string> emails, string subject, string message)
        {
           await Execute();
        }

        //public Task Execute(string apiKey, string subject, string message, List<string> emails)
        //{
        //    var client = new SendGridClient(apiKey);
        //    var msg = new SendGridMessage()
        //    {
        //        From = new EmailAddress("noreply@domain.com", "Bekenty Jean Baptiste"),
        //        Subject = subject,
        //        PlainTextContent = message,
        //        HtmlContent = message
        //    };

        //    foreach (var email in emails)
        //    {
        //        msg.AddTo(new EmailAddress(email));
        //    }

        //    Task response = client.SendEmailAsync(msg);
        //    return response;
        //}


        public async Task Execute()
        {
            var apiKey = "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"; //Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("tkolawole@inspirecoders.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("tkolawole@inspirecoders.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<a href='https://localhost:44369/api/user/Activate/1'>Activate Account</a>"; //"<a href='https://localhost:44369/api/user/Activate/2'>Activate Account</a>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
