using CorporateArena.Domain;
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

        private readonly string _SendgridKey;
        public EmailSender(string SendgridKey)
        {
            _SendgridKey = SendgridKey;
        }


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

        public async Task SendUserMessage(ContactEmail email)
        {
            var client = new SendGridClient(_SendgridKey);
            var from = new EmailAddress(email.Email, email.Username);
            var subject = "testing with default subject";
            var to = new EmailAddress("kolawoletoheeb18@yahoo.com");
            var plainContent = email.Message;
            var htmlContent = email.Message;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
