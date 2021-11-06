using EPalBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EPalBack.Helpers
{
    public class SendMail
    {

        public void SendToMail(MembrViewModel query, string gmail_account, string gmail_password)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);
            SmtpServer.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(gmail_account);
            mail.To.Add(query.ToEmail);
            mail.Subject = query.Subject;
            mail.Body = query.MailBody;
            mail.IsBodyHtml = true;
            SmtpServer.Send(mail);
        }
    }
}
