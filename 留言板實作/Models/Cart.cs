using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 留言板實作.Models
{
    public class Cart
    {
        public int UserID { get; set; }
        public string CartId { get; set; }
        public Users User { get; set; }
    }
}