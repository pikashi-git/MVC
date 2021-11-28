using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Net.DatabaseLib1.Models
{
    public class Order
    {
        [MaxLength(10)]
        public string OrderId { get; set; }

        public string CustomerId { get; set; }

        [Required]
        public string Delivery { get; set; }

        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}