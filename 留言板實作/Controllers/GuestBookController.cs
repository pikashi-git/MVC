using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 留言板實作.Models;
using 留言板實作.Services;
using 留言板實作.ViewModels;

namespace 留言板實作.Controllers
{
    public class GuestBookController : Controller
    {
        GuestbookDBService Service = new GuestbookDBService();
        UsersDBService _usersDbService = new UsersDBService();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string search, int page = 1)
        {
            Paging pages = new Paging(page);
            return PartialView(Service.GetguestbookInfoList(search, pages));
        }
        [HttpPost]
        public ActionResult List([Bind(Include = "search")] GuestbookInfoViewModel data)
        {
            return RedirectToAction("List", new { search = data.Search });
        }
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }
        [Authorize]
        [HttpPost]
        public ActionResult Create([Bind(Include = "postContent,parent")] Guestbook newData)
        {
            newData.User.Account = User.Identity.Name;
            Service.InsertGuestBook(newData);
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            Guestbook data = Service.GetGuestBook(id);
            return View(data);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="ID,postContent")] Guestbook data)
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
        [Authorize(Roles = "1,2")]
        public ActionResult Reply(int id)
        {
            Guestbook data = Service.GetGuestBook(id);
            return View(data);
        }
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
        [Authorize(Roles = "1,2")]
        public ActionResult Delete(int id)
        {
            Service.DeleteGuestBook(id);
            return RedirectToAction("Index");
        }
    }
}