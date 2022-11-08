using ETicaretAPI.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {
        public Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }


        public async Task VerifyMailAsync(string to, string userId, string resetToken)
        {
            StringBuilder mail = new();
            mail.AppendLine("Verify Email<br><strong><a target=\"_blank\" href=\"");
            mail.AppendLine("http://localhost:4200");
            mail.AppendLine("/verify/");
            mail.AppendLine(userId);
            mail.AppendLine("/");
            mail.AppendLine(resetToken);
            mail.AppendLine("\">To verify</a></strong><br><br><span style=\"font-size:12px;\">");

            await SendMailAsync(to, "Verify Email", mail.ToString());
        }
    }
}
