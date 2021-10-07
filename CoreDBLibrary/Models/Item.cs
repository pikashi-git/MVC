using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBLibrary.Models
{
    public partial class Item
    {
        public Item()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int ItemId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
