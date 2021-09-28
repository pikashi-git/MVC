using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 購物網站MVC_Demo.ViewModels
{
    public class UserLoginViewModel
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage ="請輸入帳號")]
        [MinLength(3, ErrorMessage ="最小長度3")]
        public string Account { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage ="請輸入密碼")]
        public string Password { get; set; }
    }
}