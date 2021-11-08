using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Net.DatabaseLib1.Models
{
    public class Customer
    {
        [MaxLength(10)]
        public string CustomerId { get; set; }

        [Required]
        [MaxLength(5)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }
    }
}