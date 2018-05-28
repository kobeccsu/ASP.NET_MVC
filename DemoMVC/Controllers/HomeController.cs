using DemoMVC.Filter;
using DemoMVC.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class HomeController : Controller
    {
        [UserAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Home/good")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RedirectView()
        {
            Thread.Sleep(3000);
            TempData["Name"] = "Lei zhou";
            return RedirectToAction("TempView");
        }

        public ActionResult TempView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify()
        {
            var username = Request.Form["username"];
            
            if (username == "zhoulei") {
                TempData["Name"] = username;
                return RedirectToAction("TempView");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            AuthUtil.SignOut();
            return View("Index");
        }
    }
}