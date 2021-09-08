using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 留言板實作.ViewModels
{
    public class changPasswordViewModel
    {
        [DisplayName("舊密碼")]
        [Required(ErrorMessage ="請輸入舊密碼")]
        public string Password { get; set; }

        [DisplayName("新密碼")]
        [Required(ErrorMessage = "請輸入新密碼")]
        public string NewPassword { get; set; }

        [DisplayName("再次輸入密碼")]
        [Required(ErrorMessage = "請輸入確認密碼")]
        [Compare("NewPassword", ErrorMessage ="兩次密碼不相同")]
        public string PasswordChk { get; set; }
    }
}