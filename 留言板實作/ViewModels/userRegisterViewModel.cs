using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 留言板實作.Models;

namespace 留言板實作.ViewModels
{
    public class UserRegisterViewModel
    {
        public Users Users { get; set; }
        [DisplayName("密碼")]
        [Required(ErrorMessage="請輸入密碼")]
        public string Password { get; set; }

        [DisplayName("確認密碼")]
        [Compare("Password",ErrorMessage= "二次密碼不一致")]
        [Required(ErrorMessage="請輸入確認密碼")]
        public string PasswordChk { get; set; }
    }
}