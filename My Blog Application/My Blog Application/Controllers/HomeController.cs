using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using My_Blog_Application.Models;

namespace My_Blog_Application.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Signup()
        {
            return View();
        }
       

    }
}
