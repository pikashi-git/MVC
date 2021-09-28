using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Test.Models
{
    [Table("Location")]
    public class Location
    {
        [Key]
        [DisplayName("區域")]
        public int LocationSerial { get; set; }
        [Required]
        [DisplayName("名稱")]
        public string LocationName { get; set; }
        [Required]
        [DisplayName("區域編碼")]
        public string AreaCode { get; set; }
    }
}