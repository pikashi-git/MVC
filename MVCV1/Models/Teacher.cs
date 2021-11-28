using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC網站.Models
{
    public class Teacher
    {
        [Key]
        [StringLength(4)]
        public string TeachID { get; set; }

        [Required]
        public string TeacherName { get; set; }

        public bool Gender { get; set; }

        public DateTime Birthday { get; set; }
    }
}