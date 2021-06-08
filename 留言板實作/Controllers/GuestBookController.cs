using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 留言板實作.Services;
using 留言板實作.ViewModels;

namespace 留言板實作.Controllers
{
    public class GuestBookController : Controller
    {
        guestbookDBService Service = new guestbookDBService();
        public ActionResult Index()
        {
            return View(Service.GetguestbookList());
        }
    }
}