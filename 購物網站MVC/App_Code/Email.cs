using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace 購物網站MVC_Demo.App_Code
{
    public class Email
    {
        public string Server { get; }
        public int Port { get; }
        public string Account { get; }
        public string Pwd { get; }
        public string FromName { get; }
        public string From { get; }
        public string ToName { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Msg { get; private set; }
        public Email(string subject, string content, string to, string toName)
        {
            Server = WebConfigurationManager.AppSettings["smtp_server"];
            Port = int.Parse(WebConfigurationManager.AppSettings["smtp_port"].ToString());
            Account = WebConfigurationManager.AppSettings["smtp_account"];
            Pwd = WebConfigurationManager.AppSettings["smtp_pwd"];
            FromName = WebConfigurationManager.AppSettings["fromName"];
            From = WebConfigurationManager.AppSettings["from"];
            ToName = toName;
            To = to;
            Subject = subject;
            Content = content;
        }
        public void SendMail()
        {
            //伺服器設定
            SmtpClient sendMail = new SmtpClient(Server);
            sendMail.Credentials = new System.Net.NetworkCredential(Account, Pwd);
            sendMail.EnableSsl = true;
            //信件設定
            MailMessage mailMessage = new MailMessage();
            Encoding encode = Encoding.Default;
            mailMessage.From = new MailAddress(From, FromName, encode);
            mailMessage.To.Add(new MailAddress(To, ToName, encode));
            mailMessage.Subject = Subject;
            mailMessage.Body = Content;
            mailMessage.IsBodyHtml = true;
            //寄送
            sendMail.Send(mailMessage);
        }
    }
}