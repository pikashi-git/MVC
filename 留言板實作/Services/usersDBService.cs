using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 留言板實作.App_Code;
using 留言板實作.Interfaces;
using 留言板實作.Models;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;
using 留言板實作.Security;
using 留言板實作.ViewModels;
using System.Web.Configuration;

namespace 留言板實作.Services
{
    public class usersDBService
    {
        mailService _mailService = new mailService();
        //註冊會員
        public bool RegisterUser(users _users, out string message)
        {
            bool success_1 = false;
            bool success_2 = false;
            message = string.Empty;
            string authCode = string.Empty;
            try
            {
                IDB DB = new guestbookDB(@"
insert into users(names,nick,account,password,email,role) values(@names,@nick,@account,@password,@email,@role);
select convert(varchar(max),authCode) from users where account=@account; ");
                List<SqlParameter> paraList = new List<SqlParameter>();
                paraList.Add(new SqlParameter("names", _users.names) { SqlDbType = SqlDbType.NVarChar });
                paraList.Add(new SqlParameter("nick", _users.nick) { SqlDbType = SqlDbType.NVarChar });
                paraList.Add(new SqlParameter("account", _users.account) { SqlDbType = SqlDbType.NVarChar });
                paraList.Add(new SqlParameter("password", HashPassword(_users.password)) { SqlDbType = SqlDbType.VarChar });
                paraList.Add(new SqlParameter("email", _users.email) { SqlDbType = SqlDbType.VarChar });
                paraList.Add(new SqlParameter("role", _users.role) { SqlDbType = SqlDbType.VarChar });
                DB.ParameterList = paraList.ToArray();
                authCode = DB.ActionScalar();

                if (authCode == null || string.Empty.Equals(authCode))
                {
                    message = @"新增會員失敗";
                }
                else
                {
                    success_1 = true;
                    success_2 = SendValidateMail(authCode, _users, out message);
                }
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                message = ex.Message;
            }
            return (success_1 & success_2);
        }

        //密碼Hash
        string HashPassword(string password)
        {
            string hashPassword = string.Empty;
            string saltKey = @"qwerFDSA";
            password = string.Concat(password, saltKey);
            SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
            byte[] passwordByte = Encoding.Default.GetBytes(password);
            byte[] hashByte = sha256.ComputeHash(passwordByte);
            hashPassword = Convert.ToBase64String(hashByte);
            return hashPassword;
        }

        //帳號檢查
        public bool AccountCheck(string account)
        {
            bool exist = false;
            users _user = GetUserByAccount(account);
            exist = (_user == null ? true : false);
            return exist;
        }

        //角色
        public string GetRole(string account)
        {
            users _users = GetUserByAccount(account);
            return _users is null ? "" : _users.role.ToString();
        }

        //以帳號取得會員資料
        public users GetUserByAccount(string account, bool consinderEnable = false, bool debug = false)
        {
            users _user = null;
            try
            {
                string sql = @" select top 1 * from users where account=@account ";
                if (consinderEnable)
                    sql += @" and enabled = 1 ";
                IDB DB = new guestbookDB(sql);
                List<SqlParameter> paraList = new List<SqlParameter>();
                paraList.Add(new SqlParameter("account", account) { SqlDbType = SqlDbType.NVarChar });
                DB.ParameterList = paraList.ToArray();
                SqlDataReader reader = DB.ActionReader();
                
                if (reader.Read())
                {
                    _user = new users()
                    {
                        account = reader["account"].ToString(),
                        userID = (int)reader["userID"],
                        names = reader["names"].ToString(),
                        nick = reader["nick"].ToString(),
                        email = reader["email"].ToString(),
                        role = reader["role"].ToString(),
                        authcode = reader["authcode"].ToString(),
                        enabled = (bool)reader["enabled"],
                        password = reader["password"].ToString()
                    };
                }
                reader.Close();
                DB.DisConnect();
            }
            catch (Exception ex)
            {
                _user = null;
                throw new Exception(ex.Message);
            }
            return _user;
        }

        //會員信箱驗證
        public bool validateEmail(string account, string authCode, out string message)
        {
            bool success = false;
            message = string.Empty;

            users _users = GetUserByAccount(account);
            if (_users != null)
            {
                if (_users.authcode.Equals(authCode.ToLower()))
                {
                    try
                    {
                        IDB DB = new guestbookDB(@" 
update users set validateDate=GetDate(),enabled=1 where account=@account ");
                        List<SqlParameter> paraList = new List<SqlParameter>();
                        paraList.Add(new SqlParameter("account", _users.account) { SqlDbType = SqlDbType.NVarChar });
                        DB.ParameterList = paraList.ToArray();
                        int count = DB.Action();

                        success = true;
                        message = @"已成功驗證, 已可登入";
                    }
                    catch (Exception ex)
                    {
                        //throw new Exception(ex.Message);
                        message = ex.Message;
                    }
                }
                else
                {
                    message = @"驗證碼錯誤, 請重新試過";
                }
            }
            else
            {
                message = @"請確認帳號是否無誤";
            }
            return success;
        }

        public bool SendValidateMail(string account)
        {
            bool success = false;
            users _users = GetUserByAccount(account);
            string msg = string.Empty;
            success = SendValidateMail(_users.authcode, _users, out msg);
            return success;
        }

        //寄發驗證信
        public bool SendValidateMail(string authCode, users _users, out string message)
        {
            bool success = false;
            message = string.Empty;
            string contentTmp = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/Views/Shared/RegisterEmailTmp.html"));
            UriBuilder uri = new UriBuilder(HttpContext.Current.Request.Url)
            {
                Path = $@"/Users/EmailValidate",
                Query = $@"authCode={authCode}&account={_users.account}"
            };
            string content = string.Format(contentTmp, _users.names, uri.ToString());
            bool sendStatus = _mailService.SendValidateMail(@"註冊會員驗證信", content, _users.email, _users.names);
            if (sendStatus)
            {
                success = true;
                message = @"寄送驗證信成功";
            }
            else
            {
                success = false;
                message = $@"寄送驗證信失敗, {_mailService.Msg}" ;
            }
            return success;
        }

        //登入檢查
        public bool LoginCheck(string account, string password, out string msg)
        {
            msg = string.Empty;
            bool check = false;
            users _user = GetUserByAccount(account);
            if (!(_user is null))
            {
                if (_user.enabled)
                {
                    if (HashPassword(password).Equals(_user.password))
                    {
                        check = true;
                        msg = @"已經登入成功";
                    }
                    else
                    {
                        msg = @"錯誤密碼登入失敗";
                    }
                }
                else
                {
                    msg = @"尚未信箱驗證";
                }
            }
            else
            {
                msg = @"登入失敗, 沒有這位使用者";
            }
            return check;
        }

        //加入JWT Cookie
        public void AddJwtCookie(userLoginViewModel _userLoginViewModel) 
        {
            string role = GetRole(_userLoginViewModel.account);
            JwtService jwtService = new JwtService();
            string token = jwtService.GenerateJwtToken(_userLoginViewModel.account, role);
            string cookieName = WebConfigurationManager.AppSettings["cookieName"].ToString();
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = HttpContext.Current.Server.UrlEncode(token);
            cookie.Expires = DateTime.Now.AddMinutes(Convert.ToInt32(WebConfigurationManager.AppSettings["expireMinutes"]));
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        //更改密碼
        public bool ChangeUserPassword(changPasswordViewModel _changPasswordViewModel, string account, out string msg)
        {
            msg = "更新密碼失敗";
            bool changeStatus = false;
            if (GetUserByAccount(account).password.Equals(HashPassword(_changPasswordViewModel.Password)))
            {
                string sql = $@" update users set password='{HashPassword(_changPasswordViewModel.NewPassword)}' where account='{account}'; ";
                IDB DB = new guestbookDB(sql);
                DB.Action();
                changeStatus = true;
                msg = "更新密碼成功";
            }
            return changeStatus;
        }
    }
}