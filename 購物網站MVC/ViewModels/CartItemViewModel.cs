using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.Models;

namespace 購物網站MVC_Demo.ViewModels
{
    public class CartItemViewModel
    {
        public List<CartItem> DataList { get; set; }

        public bool IsCartSave { get; set; }
    }
}