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
        guestbookDBService Service = new guestbookDBService();
        public ActionResult Index()
        {
            return View(Service.GetguestbookInfoList());
        }
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "userID,postContent,parent")] guestbook newData)
        {
            Service.InsertGuestBook(newData);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            guestbook data = Service.GetGuestBook(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(int id, [Bind(Include ="userID,postContent")] guestbook data)
        {
            data.ID = id;
            Service.UpdateGuestBook(data);
            return RedirectToAction("Index");
        }
        public ActionResult Reply(int id)
        {
            guestbook data = Service.GetGuestBook(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Reply(int id, FormCollection form)
        {
            guestbook data = new guestbook();
            data.parent = id;
            data.userID = int.Parse(form["userID_reply"].ToString());
            data.postContent = form["postContent_reply"].ToString();
            Service.ReplyGuestBook(data);
            return RedirectToAction("Index");
        }
    }
}