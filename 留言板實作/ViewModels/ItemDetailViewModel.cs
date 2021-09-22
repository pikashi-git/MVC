using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 留言板實作.Models;

namespace 留言板實作.ViewModels
{
    public class ItemDetailViewModel
    {
        public Item ItemData { get; set; }

        public bool InCart { get; set; }
    }
}