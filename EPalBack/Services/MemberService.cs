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
        private readonly Repository<Member> _member;
        private readonly Repository<Language> _language;




        public MemberService(Repository<Member> member, Repository<Language> language)
        {
            _member = member;
            _language = language;
        }

        public IEnumerable<MembrViewModel> GetMembers()
        {
            return _member.GetAll().Select(x => new MembrViewModel()
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
            var member = _member.GetAll().Where(x => x.MemberId == id);

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

       public void UpdateMember(MembrViewModel request)
        {
            var member = _member.GetAll().FirstOrDefault(x => x.MemberId == request.MemberId);

            member.MemberName = request.MemberName;
            member.Phone = request.Phone;
            member.Email = request.Email;
            member.Country = request.Country;
            member.LanguageId = request.LanguageId;
            member.Gender = request.Gender;

            _member.Update(member);
            _member.SaveChanges();

        }

        public IEnumerable<LanguageViewModel> GetAllLanguage()
        {
            var result = new LanguageViewModel();
            var LanguageAll = _language.GetAll().Select(L => new language
            {
                LanguageId = L.LanguageId,
                LanguageName = L.LanguageName
            }).ToList();
            result.LanguageAll = LanguageAll;
            yield return result;
        }

        //性別選單. (先測試,之後再確認能否濃縮成一份)
        //public IEnumerable<LanguageViewModel> GetAllGender()
        //{
        //    var result = new LanguageViewModel();
        //    var a =
        //    //var GenderAll = _member.GetAll().Select(G => gender)
        //}


    }


    
}
