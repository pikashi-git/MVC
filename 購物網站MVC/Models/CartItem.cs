using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 購物網站MVC_Demo.Models
{
    public class CartItem
    {
        public string CartId { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}