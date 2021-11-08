using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Net.DatabaseLib1.Models
{
    public class Product
    {
        [MaxLength(10)]
        public string ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Misc { get; set; }
    }
}