using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.ViewModels;
using EPalBack.Repositories;
using EPalBack.DataModels;
using System.Net.Mail;

namespace EPalBack.Services
{
    public class MemberService
    {
        private readonly Repository<Member> _repository;


        public MemberService(Repository<Member> repository)
        {
            _repository = repository;
        }

        public IEnumerable<MembrViewModel> GetMembers()
        {
            return _repository.GetAll().Select(x => new MembrViewModel()
            {
                MemberId = x.MemberId,
                MemberName = x.MemberName,
                //RegistrationDate = x.RegistrationDate,
                BackRegistDate = Convert.ToDateTime(x.RegistrationDate).Date.ToString("D"),
                Email = x.Email,
                Password = x.Password,
                Phone = x.Phone,
                Country = x.Country,
                CityId = x.CityId,
                Gender = x.Gender,
                BirthDay = x.BirthDay,
                TimeZone = x.TimeZone,
                LanguageId = x.LanguageId,
                Bio = x.Bio,
                ProfilePicture = x.ProfilePicture
            }).ToList();
        }

        public IEnumerable<MembrViewModel> GetMemberManage(int id)
        {
            var member = _repository.GetAll().Where(x => x.MemberId == id);

            return member.Select(x => new MembrViewModel()
            {
                MemberId = x.MemberId,
                MemberName = x.MemberName,
                RegistrationDate = x.RegistrationDate,
                Email = x.Email,
                Password = x.Password,
                Phone = x.Phone,
                Country = x.Country,
                CityId = x.CityId,
                Gender = x.Gender,
                BirthDay = x.BirthDay,
                TimeZone = x.TimeZone,
                LanguageId = x.LanguageId,
                Bio = x.Bio,
                ProfilePicture = x.ProfilePicture
            }).ToList();

        }


        //寄送會員信
        //public void SendFeedbackMail(string MailBody, string ToEmail, string Subject)
        //{
        //    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //    SmtpServer.Port = 587;
        //    SmtpServer.Credentials = new System.Net.NetworkCredential(gmail_account, gmail_password);
        //    SmtpServer.EnableSsl = true;
        //    MailMessage mail = new MailMessage();
        //    mail.From = new MailAddress(gmail_account);
        //    mail.To.Add(ToEmail);
        //    mail.Subject = Subject;
        //    mail.Body = MailBody;
        //    mail.IsBodyHtml = true;
        //    SmtpServer.Send(mail);

        //}
    }
}
