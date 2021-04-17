using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC網站.Controllers
{
    public class 測試Controller: Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ContentResult ForContentResult()
        {
            return Content("這是測試Content");
        }
        public EmptyResult ForEmptyResult()
        {
            return null;
        }
        public RedirectResult ForRedirectResult()
        {
            return Redirect(@"https://www.yahoo.com.tw/");
        }
        public RedirectToRouteResult ForRedirectToRoute()
        {
            return RedirectToAction("Index", "Home", null);
        }
        public ViewResult ForViewResult()
        {
            return View();
        }
        public ActionResult ForViewResult2()
        {
            return View();
        }
        public PartialViewResult ForPartialViewResult()
        {
            return PartialView();
        }
        public HttpUnauthorizedResult ForHttpUnauthorizedResult()//401
        {
            return new HttpUnauthorizedResult();
        }
        public HttpNotFoundResult ForHttpNotFoundResult()//404
        {
            return HttpNotFound("Page Not Found!!!");
        }
        public JavaScriptResult ForJavaScriptResult()
        {
            string js = "alert(\"這是測試ForJavaScriptResult\")";
            return JavaScript(js);
        }
    }
}