using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using 留言板實作.Models;

namespace 留言板實作.ViewModels
{
    public class guestbookInfoViewModel
    {
        [DisplayName("搜尋")]
        public string Search { get; set; }
        public List<guestbookInfo> guestbookInfoList { get; set; }
        public Paging pages { get; set; }
    }
}