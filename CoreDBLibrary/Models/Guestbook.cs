using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBLibrary.Models
{
    public partial class Guestbook
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string PostContent { get; set; }
        public int Parent { get; set; }
        public DateTime Createtime { get; set; }
        public DateTime? Updatetime { get; set; }
    }
}
