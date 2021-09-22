using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using 留言板實作.Services;

namespace 留言板實作.ViewModels
{
    public class ItemListViewModel
    {
        public List<int> IdList { get; set; }
        public List<ItemDetailViewModel> ItemDetailList { get; set; }
        public Paging Page { get; set; }
    }
}