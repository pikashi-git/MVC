using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.Services;

namespace 購物網站MVC_Demo.ViewModels
{
    public class ItemListViewModel
    {
        public List<int> IdList { get; set; }
        public List<ItemDetailViewModel> ItemDetailList { get; set; }
        public Paging Page { get; set; }
    }
}