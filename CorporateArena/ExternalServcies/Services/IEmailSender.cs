using CorporateArena.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorporateArena.Presentation
{
    public interface IEmailSender
    {
        Task SendEmailAsync();//List<string> emails, string subject, string message);

        Task SendUserMessage(ContactEmail email);
    }
}
