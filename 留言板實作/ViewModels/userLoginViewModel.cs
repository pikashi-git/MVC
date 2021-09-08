using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 留言板實作.ViewModels
{
    public class userLoginViewModel
    {
        [DisplayName("帳號")]
        [Required(ErrorMessage ="請輸入帳號")]
        [MinLength(3, ErrorMessage ="最小長度3")]
        public string account { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage ="請輸入密碼")]
        public string password { get; set; }
    }
}