using System;
using System.Collections.Generic;

#nullable disable

namespace CoreDBLibrary.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Names { get; set; }
        public string Nick { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Guid? Authcode { get; set; }
        public string Role { get; set; }
        public DateTime? ValidateDate { get; set; }
        public bool? Enabled { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
