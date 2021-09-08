using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 留言板實作.Models
{
    public class users
    {
        [DisplayName("編號")]
        public int userID { get; set; }

        [DisplayName("姓名")]
        [StringLength(5, MinimumLength = 3, ErrorMessage = "姓名長度需介於3-5字元")]
        public string names { get; set; }

        [DisplayName("措號")]
        [StringLength(10,MinimumLength =1,ErrorMessage ="措號長度需介於1-10字元")]
        public string nick { get; set; }
        
        [DisplayName("帳號")]
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(10,MinimumLength =3,ErrorMessage ="帳號長度需介於3-10字元")]
        //[Remote("UserCheck", "users", ErrorMessage = "此帳號已被註冊過", HttpMethod = "post")]
        [Remote("AccountCheck", "users", ErrorMessage = "此帳號已被註冊過", HttpMethod = "post")]
        public string account { get; set; }
        
        [DisplayName("密碼")]
        public string password { get; set; }
        
        [DisplayName("郵址")]
        [Required(ErrorMessage ="請輸入Email")]
        [StringLength(50,ErrorMessage ="Email長度最多50字元")]
        [EmailAddress(ErrorMessage ="這不是Email格式")]
        public string email { get; set; }
        
        [DisplayName("驗證碼")]
        public string authcode { get; set; }
        
        [DisplayName("角色")]
        public string role { get; set; }

        [DisplayName("啟用狀態")]
        public bool enabled { get; set; }
    }
}