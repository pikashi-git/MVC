using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 購物網站MVC_Demo.Models;
using 購物網站MVC_Demo.Services;
using 購物網站MVC_Demo.ViewModels;

namespace 購物網站MVC_Demo.Controllers
{
    public class GuestBookController : Controller
    {
        GuestbookDBService Service = new GuestbookDBService();
        UsersDBService _usersDbService = new UsersDBService();

        //留言板首頁
        public ActionResult Index()
        {
            return View();
        }

        //清單
        public ActionResult List(string search, int page = 1)
        {
            Paging pages = new Paging(page);
            return PartialView(Service.GetguestbookInfoList(search, pages));
        }

        //清單
        [HttpPost]
        public ActionResult List([Bind(Include = "Search")] GuestbookInfoViewModel data)
        {
            return RedirectToAction("List", new { search = data.Search });
        }

        //建立留言
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }

        //建立留言
        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "PostContent")] Guestbook newData)
        {
            newData.User.Account = User.Identity.Name;
            newData.Parent = 0;
            Service.InsertGuestBook(newData);
            return RedirectToAction("Index");
        }

        //編輯留言
        [Authorize]
        public ActionResult Edit(int id)
        {
            Guestbook data = Service.GetGuestBook(id);
            return View(data);
        }

        //編輯留言
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="ID,PostContent")] Guestbook data)
        {
            Users _user =_usersDbService.GetUserByAccount(User.Identity.Name);
            Guestbook data1 = Service.GetGuestBook(data.ID);
            data.UserID = data1.UserID;
            if (_user.UserID != data1.UserID)
            {
                ViewData["alert"] = @"不是你的貼文";
                return View(data);
            }
            else
            {
                data.ID = id;
                Service.UpdateGuestBook(data);
                return RedirectToAction("Index");
            }
        }

        //回復留言
        [Authorize(Roles = "1,2")]
        public ActionResult Reply(int id)
        {
            Guestbook data = Service.GetGuestBook(id);
            return View(data);
        }

        //回復留言
        [Authorize(Roles = "1,2")]
        [HttpPost]
        public ActionResult Reply(int id, FormCollection form)
        {
            Users _user = _usersDbService.GetUserByAccount(User.Identity.Name);
            Guestbook data = new Guestbook();
            data.Parent = id;
            data.UserID = _user.UserID;
            data.PostContent = form["postContent_reply"].ToString();
            Service.ReplyGuestBook(data);
            return RedirectToAction("Index");
        }

        //刪除留言
        [Authorize(Roles = "1,2")]
        public ActionResult Delete(int id)
        {
            Service.DeleteGuestBook(id);
            return RedirectToAction("Index");
        }
    }
}