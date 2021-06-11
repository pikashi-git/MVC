using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 留言板實作.Models
{
    public class guestbookInfo
    {
        public int ID { get; set; }
        public int userID { get; set; }
        public string postContent { get; set; }
        public int parent { get; set; }
        public DateTime createtime { get; set; }
        public string names { get; set; }
        public string nick { get; set; }
    }
}