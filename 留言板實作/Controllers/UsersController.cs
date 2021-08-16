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
            ViewData["ValidateMMsg"] = msg;
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
    }
}