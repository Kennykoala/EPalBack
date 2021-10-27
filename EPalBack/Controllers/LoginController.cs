using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPalBack.Helpers;

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
        [HttpGet]
        public IActionResult Login(string username)
        {
            return Ok(_jwtHelper.GenerateToken(username));
        }


        [Authorize]
        [HttpGet]
        public IActionResult Test()
        {
            return Ok("通過");
        }



    }
}
