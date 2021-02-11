using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_Blog_Application.Models;

namespace My_Blog_Application.Controllers
{
    public class PublicUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Signup(PublicUser u)
        {
            bool gt = false;
           
            if(ModelState.IsValid)
            { 

                PublicUserRepo.SignUp(u,ref gt);
            if(gt)
            {
                    HttpContext.Session.SetString("Name", u.Name);
                    return View("HomePage",u);

            }
            else
            {
                   return View();

            }
        }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
    }
}
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Login(PublicUser c)
        {
            bool isLogin = false;
           PublicUserRepo.Login(c.Name, c.Password, ref isLogin);
            if(isLogin)
            {
                 HttpContext.Session.SetString("Name",c.Name);
                return View("HomePage",c);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
        [HttpGet]
        public ViewResult CreateBlog(string Name)
        {
            return View(Name);
        }

        public ViewResult Logout()
        {
            HttpContext.Session.Remove("Name");
            return View("Index");

        }
        [HttpPost]
        public ViewResult CreateBlog(string nam,Blog b)
        {
            b.Date = DateTime.Today.ToString();
            if (ModelState.IsValid)
            {
                string name = HttpContext.Session.GetString("Name");
                int id =PublicUserRepo.GetId(name);
                BlogRepo.AddBlog(b,id);
                PublicUser usr = PublicUserRepo.getUserbyId(id);
                return View("HomePage",usr);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }
        }
        [HttpGet] 
        public ViewResult HomePage()
        {
            string name = HttpContext.Session.GetString("Name");
            int id = PublicUserRepo.GetId(name);
            PublicUser usr = PublicUserRepo.getUserbyId(id);
            return View(usr);
        }
        [HttpPost]
        public ViewResult HomePage(int myid,Blog b)
        {
            string name = HttpContext.Session.GetString("Name");
            int id = PublicUserRepo.GetId(name);
            PublicUser usr = PublicUserRepo.getUserbyId(id);
            return View(usr);
          
        }
        [HttpGet]
        public ViewResult About()
        {
            return View();
        }
        [HttpGet]
        public ViewResult Profile()
        {
            string name = HttpContext.Session.GetString("Name");
            int id = PublicUserRepo.GetId(name);
            Profile pro = ProfileRepo.GetProfile(id);
            return View("Profile",pro);
        }
        [HttpPost]
        public IActionResult Profile(Profile pro)
        {
            if(ModelState.IsValid)
            {
                string name = HttpContext.Session.GetString("Name");
                int id = PublicUserRepo.GetId(name);
                ProfileRepo.DeleteProfile(id);
                ProfileRepo.UpdateProfile(id, pro);
                HttpContext.Session.SetString("Name", pro.Usrinfo.Name); //Incase if user changes the name
               
                return View("HomePage", pro.Usrinfo);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View("Profile",pro);
            }
           
        }
        public ViewResult ViewMyBlogs()
        {
            string name = HttpContext.Session.GetString("Name");
            int id = PublicUserRepo.GetId(name);
           List<Blog> blogs= BlogRepo.getMyBlogs(id);
            return View(blogs);
        }
        public ViewResult ViewAllBlogs()
        {
            List<Stream> lst = PublicUserRepo.getUserandPosts();
            List<Stream> lstnew = Stream.ScanStream(lst);
            return View(lstnew);
        }
        public ViewResult Remove(int id)
        {
            BlogRepo.RemoveBlog(id);
            string name = HttpContext.Session.GetString("Name");
            int myid = PublicUserRepo.GetId(name);
            List<Blog> blogs = BlogRepo.getMyBlogs(myid);
            return View("ViewMyBlogs",blogs);
        }
        public ViewResult Edit(int id)
        {
             Blog b = BlogRepo.getBlogById(id);
            return View("Edit", b);

        }
        [HttpPost]
        public ViewResult Edit(Blog b,int blogid)
        {
            string name = HttpContext.Session.GetString("Name");
            int id = PublicUserRepo.GetId(name);
            List<Blog> myBlogs = BlogRepo.getMyBlogs(id);
            if (ModelState.IsValid)
            {
                foreach (Blog bl in myBlogs)
                {
                    if (bl.blog_Id == b.blog_Id)
                    {
                        bl.Title = b.Title;
                        bl.Content = b.Content;
                        bl.Date = b.Date;
                        BlogRepo.RemoveBlog(bl.blog_Id);
                        BlogRepo.AddBlog(b, id); //Sath hi database ma b update kr dia h
                        break;
                    }
                }

                return View("ViewMyBlogs",myBlogs);
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Please enter correct data");
                return View();
            }

        }

    }
}
