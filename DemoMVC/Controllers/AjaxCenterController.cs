using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoMVC.Controllers
{
    public class AjaxCenterController : Controller
    {
        // GET: AjaxCenter
        public JsonResult Index()
        {
            var json = "{many:1}";
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        // GET: AjaxCenter/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
