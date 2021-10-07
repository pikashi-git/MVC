using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreMVC_Test.Models;
using CoreDBLibrary.Models;

namespace CoreMVC_Test.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly GuestBookContext _GuestBookContext;
        public HomeController(GuestBookContext guestBookContext)
        {
            _GuestBookContext = guestBookContext;
        }

        public IActionResult Index()
        {
            ViewData["Content"] = (from a in _GuestBookContext.Guestbooks
                                 where a.Id == 43
                                 select a.PostContent).SingleOrDefault();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
