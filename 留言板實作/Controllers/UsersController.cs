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
        mailService _mailService = new mailService();
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
                string authCode = string.Empty;
                bool registerStatus = _usersDBService.RegisterUser(_userRegisterViewModel.Users, out message, out authCode);
                if (registerStatus)
                {
                    //寄送驗證信
                    string contentTmp = System.IO.File.ReadAllText("~/Views/Shared/RegisterEmailTmp.html");
                    UriBuilder uri = new UriBuilder(Request.Url)
                    {
                        Path = Url.Action("EmailValidate", "users", new { auchCode = authCode, account = _userRegisterViewModel.Users.account })
                    };
                    string content = string.Format(contentTmp, _userRegisterViewModel.Users.names, uri.ToString());
                    bool sendStatus = _mailService.SendValidateMail(@"註冊會員驗證信", content, _userRegisterViewModel.Users.email, _userRegisterViewModel.Users.names);
                    if (sendStatus)
                    {
                        TempData["RegisterStatus"] = @"註冊成功, 請去收取驗證信!!";
                        return RedirectToAction("RegisterResult", "users");
                    }
                    else
                    {
                        TempData["RegisterStatus"] = @"寄送驗證信失敗!!";
                    }
                }
                else
                {
                    TempData["RegisterStatus"] = @"註冊失敗!!";
                }
            }
            _userRegisterViewModel.Password = null;
            _userRegisterViewModel.PasswordChk = null;
            return View(_userRegisterViewModel);
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
    }
}