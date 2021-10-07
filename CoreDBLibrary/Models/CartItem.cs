using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBLibrary.Models
{
    public partial class CartItem
    {
        public string CartId { get; set; }
        public int ItemId { get; set; }

        public virtual Item Item { get; set; }
    }
}
