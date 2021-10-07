using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBLibrary.Models
{
    public partial class Cart
    {
        public int UserId { get; set; }
        public string CartId { get; set; }

        public virtual User User { get; set; }
    }
}
