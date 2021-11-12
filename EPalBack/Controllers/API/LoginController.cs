using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Helpers;
using EPalBack.ViewModels;

namespace EPalBack.Controllers
{
    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly JwtHelper _jwtHelper;

        public LoginController()
        {
            _jwtHelper = new JwtHelper();
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        
        [HttpPost]
        public IActionResult Login(LoginViewModel userdata)
        {
            if(userdata.Username == "admin" && userdata.Password == "ADMIN")
            {
            return Ok(_jwtHelper.GenerateToken(userdata.Username));
            }
            else
            {
                //throw new Exception("登入失敗，帳號或密碼錯誤");
                return null;
            }
        }


        [Authorize]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("通過");
        }



    }
}
