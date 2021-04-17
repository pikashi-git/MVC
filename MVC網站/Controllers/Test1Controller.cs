﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC網站.Controllers
{
    public class Test1Controller : Controller
    {
        public ActionResult Index(string name)
        {
            ViewBag.Title = "Test Home Page";
            ViewBag.Page = "Test!";
            ViewData["name"] = name;
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
        public HttpNotFoundResult ForHttpNotFound()
        {
            return HttpNotFound("Page Not Found");
        }
        public JavaScriptResult ForJavascriptResult()
        {
            string js = "<script>alert(\"這是javascript範例\")</script>";
            return JavaScript(js);
        }
        public JsonResult ForJsonResult()
        {
            var JsonContent = new {
                id = 1,
                content = new[] { "這是JsonResult測試內容", "這是JsonResult測試內容2" }
            };
            return Json(JsonContent, JsonRequestBehavior.AllowGet);
        }
        public FilePathResult ForFilePathResult()
        {
            string path = Server.MapPath("~/images/image1.png");
            return File(path, "application/x-png", "測試.jpg");
        }
        public FileContentResult ForFileContentResult()
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes("這是測試FileContent");
            return File(data, "text/plain", "測試.txt");
        }
        public FileStreamResult ForFileStreamResult()
        {
            var path = Server.MapPath("~/images/image1.png");
            FileStream fs = new FileStream(path, FileMode.Open);
            return File(fs, "text/plain", "FileStreamResult.png");
        }
        public ContentResult ForContentResult1(string TestName)
        {
            return Content("這是測試" + TempData["TestName"]);
        }
    }
}