using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Net.DatabaseLib1.Models
{
    public class OrderDetail
    {
        [MaxLength(10)]
        public string OrderDetailId { get; set; }

        [Required]
        [MaxLength(10)]
        public string OrderId { get; set; }

        [Required]
        [MaxLength(10)]
        public string ProductId { get; set; }

        [DefaultValue(0)]
        public int Pic { get; set; }

        public Product Product { get; set; }
    }
}