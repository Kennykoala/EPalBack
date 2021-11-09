using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Services;
using EPalBack.ViewModels.APIBase;
using EPalBack.ViewModels;

namespace EPalBack.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MemberService _memberService;

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public ApiResponse GetMembers()
        {
            try
            {
                var result = _memberService.GetMembers();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

  
        [HttpGet("{id:int}")]
        public ApiResponse GetMemberManage(int id)
        {
            try
            {
                var result = _memberService.GetMemberManage(id);
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch(Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }
        }

        [HttpPost]
        public ApiResponse UpdateMember(MembrViewModel request)
        {
            try
            {
                _memberService.UpdateMember(request);
                return new ApiResponse(APIStatus.Success, string.Empty, true);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, false);
            }
        }

        [HttpGet]
        public ApiResponse GetAllLanguage()
        {
            try
            {
                var result = _memberService.GetAllLanguage();
                return new ApiResponse(APIStatus.Success, string.Empty, result);
            }
            catch (Exception ex)
            {
                return new ApiResponse(APIStatus.Fail, ex.Message, null);
            }

        }


    }
}
