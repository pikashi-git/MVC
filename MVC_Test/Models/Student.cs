using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC網站.Models
{
    public class Student
    {
        [StringLength(4)]
        public string StudentID { get; set; }

        [Key]
        [Required]
        public string StudentName { get; set; }

        public bool Gender { get; set; }

        public DateTime Birthday { get; set; }
    }
}