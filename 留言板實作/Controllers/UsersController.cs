using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 留言板實作.Models;

namespace 留言板實作.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(users _users)
        {
            return View();
        }
    }
}