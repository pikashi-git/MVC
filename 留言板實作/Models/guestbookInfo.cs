using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 留言板實作.Models
{
    public class guestbookInfo
    {
        [DisplayName("編號")]
        public int ID { get; set; }
        [DisplayName("會員編號")]
        [Required(ErrorMessage = "請輸入會員編號")]
        [StringLength(5, ErrorMessage = "填寫內容過長")]
        public int userID { get; set; }
        [DisplayName("張貼內容")]
        [Required(ErrorMessage = "張貼內容不能空白")]
        [StringLength(100, ErrorMessage = "張貼內容過多")]
        public string postContent { get; set; }
        [DisplayName("回應貼文")]
        public int parent { get; set; }
        [DisplayName("張貼時間")]
        public DateTime createtime { get; set; }
        [DisplayName("姓名")]
        public string names { get; set; }
        [DisplayName("別號")]
        public string nick { get; set; }
    }
}