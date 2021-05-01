using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC網站.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ContentResult ForContentResult1()
        {
            return Content("這是測試" + TempData["TestName"] + "; " + ViewData["TestName1"]);
        }

        public JsonResult TestRemote(string remote)
        {
            //if (remote.Equals("1"))
            //    return Json(true, JsonRequestBehavior.AllowGet);
            //else
            return Json(false, JsonRequestBehavior.AllowGet);
        }
    }
}