using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.Models;

namespace 購物網站MVC_Demo.ViewModels
{
    public class ItemCreateViewModel
    {
        public Item ItemData { get; set; }

        [DisplayName("商品圖片")]
        [FileExtensions(ErrorMessage ="所上傳檔案不是圖片")]
        public HttpPostedFile ItemImage { get; set; }
        //[FileExtensions(ErrorMessage = "所上傳檔案不是圖片", Extensions = "jpg,png")]
        //public HttpPostedFileBase ItemImage { get; set; }
    }
}