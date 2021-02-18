using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace StudentsAccounting.Services
{
    public class MailServices : IMailServices
    {
        private readonly IConfiguration configuration;

        public MailServices(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendMailAsync(string toMail, string subject, string content)
        {
            var apiKey = configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("turchyn_ak17@nuwm.edu.ua", "[ШЕРЛОК]");
            var to = new EmailAddress(toMail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            await client.SendEmailAsync(msg);
        }
    }
}
