using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 購物網站MVC_Demo.Models
{
    public class Cart
    {
        public int UserID { get; set; }
        public string CartId { get; set; }
        public Users User { get; set; }
    }
}