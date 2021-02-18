using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsAccounting.Services
{
    public interface IMailServices
    {
        Task SendMailAsync(string toMail, string subject, string content);
    }
}
