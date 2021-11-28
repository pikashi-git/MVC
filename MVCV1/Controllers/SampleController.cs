using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC網站.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public ActionResult Index(string view)
        {
            return View(view);
        }
    }
}