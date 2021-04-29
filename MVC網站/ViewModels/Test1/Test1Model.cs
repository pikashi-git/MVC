using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace MVC網站.ViewModels.Test1
{
    public class Test1Model
    {
        [DisplayName("輸入姓名")]
        [Required(ErrorMessage = "未輸入姓名")]
        [StringLength(7, ErrorMessage = "內容必須介於2-7字元", MinimumLength = 2)]
        public string name { get; set; }

        [DisplayName("輸入年齡")]
        [Required(ErrorMessage = "未輸入年齡")]
        [Range(10, 100, ErrorMessage = "必須介於10-100之間")]
        [Compare("reage", ErrorMessage = "兩次輸入年齡不同")]
        public int? age { get; set; }

        [DisplayName("再次輸入年齡")]
        [Required(ErrorMessage = "未再次輸入年齡")]
        public int? reage { get; set; }

        [DisplayName("輸入電話")]
        [RegularExpression(@"^[0-9]{2,4}-?[0-9]{3,4}-?[0-9]{4}$", ErrorMessage = "請輸入正確電話號碼")]
        public string phone { get; set; }

        [EmailAddress(ErrorMessage = "Email格式有問題")]
        [DisplayName("信箱")]
        public string Email { get; set; }

        [Url(ErrorMessage = "網址格式有問題")]
        [DisplayName("網址")]
        public string Website { get; set; }

        [DisplayName("輸入時間")]
        public DateTime? time { get; set; }

        [FileExtensions(ErrorMessage = "上傳檔案不是指定類型", Extensions = "txt")]
        //[FileExtensions(ErrorMessage = "上傳檔案不是指定類型")]
        [DisplayName("上傳檔案")]
        public string file { get; set; }
    }
}