using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 留言板實作.Models
{
    public class cartSave
    {
        public int userID { get; set; }
        public string cart_id { get; set; }
        public users user { get; set; }
    }
}