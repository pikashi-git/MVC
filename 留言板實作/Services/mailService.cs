using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using 留言板實作.App_Code;

namespace 留言板實作.Services
{
    public class MailService
    {
        public string Msg { get; set; }
        public bool SendValidateMail(string subject, string content, string to, string toName)
        {
            bool success = false;
            try
            {
                Email email = new Email(subject, content, to, toName);
                email.SendMail();
                success = true;
                Msg = "已經寄送成功";
        }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                success = false;
                Msg = ex.Message;
            }
            return success;
        }
    }
}