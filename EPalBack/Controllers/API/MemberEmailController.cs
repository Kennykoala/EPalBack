using EPalBack.Services;
using EPalBack.ViewModels;
using EPalBack.ViewModels.APIBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using EPalBack.Helpers;

namespace EPalBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberEmailController : ControllerBase
    {
        string gmail_account = "johnsonepal061@gmail.com";
        string gmail_password = "qqqq6666";

        [HttpPost]
        public ApiResponse PostMemberEmail([FromBody] MembrViewModel query)
        {
            SendMail send = new SendMail();
            send.SendToMail(query, gmail_account,gmail_password);
            return new ApiResponse(APIStatus.Success, string.Empty, true);

        }

        

        //[HttpPost]
        //public ApiResponse PostMemberEmail([FromBody] MembrViewModel query)
        //{
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //    SmtpServer.Port = 587;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);
        //    SmtpServer.EnableSsl = true;
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress(gmail_account);
        //    mail.To.Add(query.ToEmail);
        //    mail.Subject = query.Subject;
        //    mail.Body = query.MailBody;
        //    mail.IsBodyHtml = true;
        //    SmtpServer.Send(mail);

        //    return new ApiResponse(APIStatus.Success, string.Empty, true);


        //}

    }
}
