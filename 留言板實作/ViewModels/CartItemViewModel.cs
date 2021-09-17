using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 留言板實作.Models;

namespace 留言板實作.ViewModels
{
    public class CartItemViewModel
    {
        public List<CartItem> DataList { get; set; }

        public bool IsCartSave { get; set; }
    }
}