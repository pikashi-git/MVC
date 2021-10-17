using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NetMVC.Models
{
    public class Department
    {
        [Key]
        [DisplayName("部門編號")]
        public int DepartmentID { get; set; }
        [Required]
        [DisplayName("部門名稱")]
        public string DepartmentName { get; set; }
        [DisplayName("部門位置")]
        public string DepartmentAddress { get; set; } 
        [DisplayName("備註")]
        public string Misc { get; set; }
    }
}