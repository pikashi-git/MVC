using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using 留言板實作.Models;
using 留言板實作.Services;

namespace 留言板實作.ViewModels
{
    public class GuestbookInfoViewModel
    {
        [DisplayName("搜尋")]
        public string Search { get; set; }
        public List<GuestbookInfo> GuestbookInfoList { get; set; }
        public Paging Pages { get; set; }
    }
}