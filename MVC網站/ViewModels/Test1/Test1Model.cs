using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC網站.ViewModels.Test1
{
    public class Test1Model
    {
        [DisplayName("輸入姓名")]
        [Required(ErrorMessage="未輸入姓名")]
        public string name { get; set; }
        [DisplayName("輸入年齡")]
        [Required(ErrorMessage = "未輸入年齡")]
        public int? age { get; set; }
        [DisplayName("輸入電話")]
        public string phone { get; set; }
        [DisplayName("輸入時間")]
        public DateTime? time { get; set; }
    }
}