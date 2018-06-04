using DemoMVC.LocalDbContext;
using DemoMVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DemoMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login_User user)
        {
            //if (!User.Identity.IsAuthenticated)
            //{
            //var db = new LocalDbContext.LocalDb();
            //var result = (from u in db.Login_User
            //    where u.Username == user.Username && u.Password == user.Password
            //    select u).FirstOrDefault();
            //if (result != null)
            //{
            //AuthUtil.Register(user.Username, user.Password);
            //return Redirect(Request.UrlReferrer.ToString());
            //}
            //    return View();
            //}

            var result = AuthUtil.SignIn(user.Username, user.Password, true);
            if (result) { 
                return Redirect(Request.UrlReferrer.ToString());
            }
            ViewBag.ResponseMessage = "Wrong username or password";
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Login_User user)
        {
            AuthUtil.Register(user.Username, user.Password);
            return Redirect("/Home/Index");
        }
    }
}