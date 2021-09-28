using MVC_Test.Filters;
using MVC_Test.ViewModels.Test1;
using System;
using System.Configuration;
using System.IO;
using System.Web.Mvc;

namespace MVC_Test.Controllers
{
    ////[Authorize]
    public class Test1Controller : Controller
    {
        [AllowAnonymous]
        //[RequireHttps]
        //[ValidateInput(false)]
        [OutputCache(Duration = 30)]
        [CustomFilter]
        public ActionResult Index(string name, int? age, int? reage, string phone, string email, string website, DateTime? time
            , FormCollection form
            , [Bind(Exclude = "time")] Test1Model testNodel)
        {
            ViewBag.Title = "Test Home Page";
            ViewBag.Page = "Test!";
            

            /*
             * 參數方式
             */
            //ViewData["name"] = name;
            //ViewData["age"] = age;
            //ViewData["reage"] = reage;
            //ViewData["phone"] = phone;
            //ViewData["email"] = email;
            //ViewData["website"] = website;
            //ViewData["file"] = file;
            //ViewData["time"] = time;

            /*
             * FormCollection方式
             */
            //ViewData["name"] = form["name"];
            //ViewData["age"] = form["age"];
            //ViewData["reage"] = form["reage"];
            //ViewData["phone"] = form["phone"];
            //ViewData["email"] = form["email"];
            //ViewData["website"] = form["website"];
            //ViewData["file"] = form["file"];
            //ViewData["time"] = form["time"];

            /*
             * 物件Model方式
             */
            ViewData["name"] = testNodel.name;
            ViewData["age"] = testNodel.age != null ? testNodel.age.ToString() : "";
            ViewData["reage"] = testNodel.reage != null ? testNodel.reage.ToString() : "";
            ViewData["phone"] = testNodel.phone;
            ViewData["email"] = testNodel.Email;
            ViewData["website"] = testNodel.Website;
            ViewData["file"] = testNodel.file;
            ViewData["time"] = testNodel.time;
            if (ModelState.IsValid)
            {
                ViewBag.Message = "資料通過驗證";
            }
            else {
                ViewBag.Message = "資料未通過驗證";
                //if (ModelState != null && ModelState.Count > 0)
                //    ModelState.Clear();
            }

            /*
             * TryUpdate
             */
            //UpdateModel<Test1Model>(testNodel);
            //ViewData["name"] = testNodel.name;
            //ViewData["age"] = testNodel.age != null ? testNodel.age.ToString() : "";
            //ViewData["reage"] = testNodel.reage != null ? testNodel.reage.ToString() : "";
            //ViewData["phone"] = testNodel.phone;
            //ViewData["email"] = testNodel.Email;
            //ViewData["website"] = testNodel.Website;
            //ViewData["time"] = testNodel.time;
            //ViewData["time1"] = testNodel.time1;
            //ViewData["file"] = testNodel.file;
            //ViewBag.Message = "資料通過驗證";
            //if (TryUpdateModel<Test1Model>(testNodel))
            //{
            //    ViewData["name"] = testNodel.name;
            //    ViewData["age"] = testNodel.age != null ? testNodel.age.ToString() : "";
            //    ViewData["reage"] = testNodel.reage != null ? testNodel.reage.ToString() : "";
            //    ViewData["phone"] = testNodel.phone;
            //    ViewData["email"] = testNodel.Email;
            //    ViewData["website"] = testNodel.Website;
            //    ViewData["time"] = testNodel.time;
            //    ViewData["time1"] = testNodel.time1;
            //    ViewData["file"] = testNodel.file;
            //    ViewBag.Message = "資料通過驗證";
            //}

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
        [AllowAnonymous]
        public ActionResult ForViewResult2()
        {
            return View();
        }
        [AllowAnonymous]
        [ChildActionOnly]
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
        [Authorize(Users = "vincent")]
        public ActionResult ForCreate()
        {
            return View();
        }
        [AllowAnonymous]
        //[RequireHttps]
        [ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        public JsonResult TestRemote(string remote)
        {
            //if (remote.Equals("1"))
            //    return Json(true, JsonRequestBehavior.AllowGet);
            //else
                return Json(false, JsonRequestBehavior.AllowGet);
        }
        [AllowAnonymous]
        public ActionResult Partial()
        {
            ViewData["title"] = "測試";
            return PartialView();
        }
    }
}