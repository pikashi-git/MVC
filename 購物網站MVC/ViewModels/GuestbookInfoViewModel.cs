using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.Models;
using 購物網站MVC_Demo.Services;

namespace 購物網站MVC_Demo.ViewModels
{
    public class GuestbookInfoViewModel
    {
        [DisplayName("搜尋")]
        public string Search { get; set; }
        public List<GuestbookInfo> GuestbookInfoList { get; set; }
        public Paging Pages { get; set; }
    }
}