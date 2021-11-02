using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.ViewModels;
using EPalBack.Repositories;
using EPalBack.DataModels;

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
    }
}
