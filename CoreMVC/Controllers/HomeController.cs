using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreMVC.Models;
using CoreDBLibrary.Models;

namespace CoreMVC.Controllers
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

        IList<Employee> employees = new List<Employee>();
        public IActionResult Index2()
        {
            employees.Add(new Employee { Id = "1", Name = "Name1", Age = 1, Gender = 1 });
            employees.Add(new Employee { Id = "2", Name = "Name2", Age = 2, Gender = 2 });
            employees.Add(new Employee { Id = "3", Name = "Name3", Age = 3, Gender = 3 });
            employees.Add(new Employee { Id = "4", Name = "Name4", Age = 4, Gender = 4 });
            employees.Add(new Employee { Id = "5", Name = "Name5", Age = 55, Gender = 5 });

            return View(employees);
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
