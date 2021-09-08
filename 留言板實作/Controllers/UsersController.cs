using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 留言板實作.Models;
using 留言板實作.Services;
using 留言板實作.ViewModels;
using System.Web.Configuration;
using System.IO;
using System.Web.Security;
using 留言板實作.Security;

namespace 留言板實作.Controllers
{
    public class UsersController : Controller
    {
        usersDBService _usersDBService = new usersDBService();
        // GET: Users
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "guestbook");
            return View();
        }

        [HttpPost]
        public ActionResult Register(userRegisterViewModel _userRegisterViewModel)
        {
            if (ModelState.IsValid)
            {
                //新增會員資料
                _userRegisterViewModel.Users.password = _userRegisterViewModel.Password;
                string message = string.Empty;
                bool registerStatus = _usersDBService.RegisterUser(_userRegisterViewModel.Users, out message);

                if (registerStatus)
                {
                    TempData["RegisterStatus"] = registerStatus;
                    TempData["RegisterMsg"] = @"註冊成功, 請去收取驗證信!!";
                }
                else
                {
                    TempData["RegisterStatus"] = registerStatus + ", " + message;
                    TempData["RegisterMsg"] = (message.Equals(@"寄送驗證信失敗") ? $@"<br /><a href=""/Users/SendValidateMail?account={_userRegisterViewModel.Users.account}"">再寄一次</a>" : string.Empty);
                }
            }
            return RedirectToAction("RegisterResult", "users");
        }

        //註冊結果
        public ActionResult RegisterResult()
        {
            return View();
        }

        //檢查帳號是否可註冊
        public JsonResult AccountCheck(userRegisterViewModel _userRegisterViewModel)
        {
            return Json(_usersDBService.AccountCheck(_userRegisterViewModel.Users.account), JsonRequestBehavior.AllowGet);
        }

        //驗證信驗證
        public ActionResult EmailValidate(string account, string authcode)
        {
            string msg = string.Empty;
            bool result = _usersDBService.validateEmail(account, authcode, out msg);
            ViewData["ValidateResult"] = result;
            ViewData["ValidateMsg"] = msg;
            return View();
        }

        //重寄認證信
        public ActionResult SendValidateMail(string account)
        {
            bool success = _usersDBService.SendValidateMail(account);

            if (success)
            {
                TempData["SendMailStatus"] = "寄送成功";
            }
            else
            {
                TempData["SendMailStatus"] = "寄送失敗";
            }
            return View();
        }

        //登入
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "GuestBook");
            return View();
        }

        //登入
        [HttpPost]
        public ActionResult Login(userLoginViewModel _userLoginViewModel)
        {
            bool success = _usersDBService.LoginCheck(_userLoginViewModel.account, _userLoginViewModel.password, out string msg);
            if (success)
            {
                /*
                string role = _usersDBService.GetRole(_userLoginViewModel.account);
                JwtService jwtService = new JwtService();
                string token = jwtService.GenerateJwtToken(_userLoginViewModel.account, role);
                string cookieName = WebConfigurationManager.AppSettings["cookieName"].ToString();
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie.Value = Server.UrlEncode(token);
                cookie.Expires = DateTime.Now.AddMinutes(Convert.ToInt32(WebConfigurationManager.AppSettings["expireMinutes"]));
                Response.Cookies.Add(cookie);
                */
                _usersDBService.AddJwtCookie(_userLoginViewModel);
                return RedirectToAction("Index", "GuestBook");
            }
            ModelState.AddModelError("loginMsg", msg);
            //return View(_userLoginViewModel);
            return View();
        }

        public ActionResult Logout()
        {
            string cookieName = WebConfigurationManager.AppSettings["cookieName"].ToString();
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Expires = DateTime.Now.AddYears(-1);
            cookie.Values.Clear();
            Response.Cookies.Set(cookie);
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(changPasswordViewModel _changPasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                string msg = "";
                _usersDBService.ChangeUserPassword(_changPasswordViewModel, User.Identity.Name, out msg);
                ViewData["changePasswordMsg"] = "viewdata: " + msg;
                ModelState.AddModelError("AddModelError", "AddModelError: " + msg);
            }
            return View();
        }
    }
}