using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 購物網站MVC_Demo.Models
{
    public class Users
    {
        [DisplayName("編號")]
        public int UserID { get; set; }

        [DisplayName("姓名")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "姓名長度需介於3-5字元")]
        public string Names { get; set; }

        [DisplayName("措號")]
        [StringLength(10,MinimumLength =1,ErrorMessage ="措號長度需介於1-10字元")]
        public string Nick { get; set; }
        
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(10,MinimumLength =3,ErrorMessage ="帳號長度需介於3-10字元")]
        //[Remote("UserCheck", "users", ErrorMessage = "此帳號已被註冊過", HttpMethod = "post")]
        [Remote("AccountCheck", "users", ErrorMessage = "此帳號已被註冊過", HttpMethod = "post")]
        public string Account { get; set; }
        
        [DisplayName("密碼")]
        public string Password { get; set; }
        
        [DisplayName("郵址")]
        [Required(ErrorMessage ="請輸入Email")]
        [StringLength(50,ErrorMessage ="Email長度最多50字元")]
        [EmailAddress(ErrorMessage ="這不是Email格式")]
        public string Email { get; set; }
        
        [DisplayName("驗證碼")]
        public string Authcode { get; set; }
        
        [DisplayName("角色")]
        public string Role { get; set; }

        [DisplayName("啟用狀態")]
        public bool Enabled { get; set; }
    }
}