using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC網站.ViewModels.Test1
{
    public class Test1Model
    {
        [Required]
        public string name { get; set; }
        public int? age { get; set; }
        public string phone { get; set; }
        public DateTime? time { get; set; }
    }
}