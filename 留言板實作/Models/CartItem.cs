using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 留言板實作.Models
{
    public class CartItem
    {
        public string CartId { get; set; }
        public int ItemID { get; set; }
        public Item Item { get; set; }
    }
}