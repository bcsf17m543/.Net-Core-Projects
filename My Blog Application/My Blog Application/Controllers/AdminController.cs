using Microsoft.AspNetCore.Mvc;
using My_Blog_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Blog_Application.Controllers
{
    public class AdminController:Controller
    {
      

        public ViewResult Index()
        {
            return View();
        }
        public ViewResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ViewResult AddUser(PublicUser usr)
        {
            if(ModelState.IsValid && usr.IsCorrectNumber(usr.Phone))
            {
                bool isAdded = false; 
                PublicUserRepo.SignUp(usr, ref isAdded);
                List<PublicUser> users = PublicUserRepo.GetAllUsers();
                return View("AdminDash",users);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
        public ViewResult Update(int id)
        {
            PublicUser pu = PublicUserRepo.getUserbyId(id);
            return View("Update", pu);

        }
        [HttpPost]
        public ViewResult Update(PublicUser pu)
        {
            if(ModelState.IsValid)
            {
                bool dummy = false;
                PublicUserRepo.RemoveById(pu.id);
                PublicUserRepo.SignUp(pu, ref dummy);
                List<PublicUser> users = PublicUserRepo.GetAllUsers();
                return View("AdminDash", users);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
        public ViewResult Remove(int id)
        {
            BlogRepo.RemoveBlog(id);
            PublicUserRepo.RemoveById(id);
            List<PublicUser> users = PublicUserRepo.GetAllUsers();
            return View("AdminDash", users);
        }
        [HttpPost]
        public ViewResult LoginAdmin(Admin adm)
        {
            bool isLogin = false;
            AdminRepo.Login(adm.Code, ref isLogin);
            if (isLogin)
            {
                List<PublicUser> users = PublicUserRepo.GetAllUsers();
                return View("AdminDash",users);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }

        }
    }
}
