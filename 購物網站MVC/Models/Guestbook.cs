using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace 購物網站MVC_Demo.Models
{
    public class Guestbook
    {
        [DisplayName("編號")]
        public int ID { get; set; }
        
        [DisplayName("會員編號")]
        [Required(ErrorMessage ="請輸入會員編號")]
        public int UserID { get; set; }
        
        [DisplayName("張貼內容")]
        [Required(ErrorMessage ="張貼內容不能空白")]
        [StringLength(100,ErrorMessage ="張貼內容過多")]
        public string PostContent { get; set; }
        
        [DisplayName("回應貼文")]
        public int Parent { get; set; }
        
        [DisplayName("張貼時間")]
        public DateTime Createtime { get; set; }

        [DisplayName("更新時間")]
        public DateTime Updatetime { get; set; }

        public Users User { get; set; } = new Users();
    }
}