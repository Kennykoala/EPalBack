using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EPalBack.Controllers.Epal
{
    
    public class EpalBackController : Controller
    {
        //[Authorize]
        public IActionResult Product()
        {
            return View();
        }
        //[Authorize]
        public IActionResult Order()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Member()
        {
            return View();
        }
    }
}
