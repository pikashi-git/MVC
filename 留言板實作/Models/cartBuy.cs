using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 留言板實作.Models
{
    public class cartBuy
    {
        public string cart_id { get; set; }
        public int itemID { get; set; }
        public Items items { get; set; }
    }
}