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

namespace 留言板實作.Services
{
    public class usersDBService
    {
        //註冊會員
        public bool RegisterUser(users _users, out string message, out string authCode)
        {
            bool success = false;
            message = string.Empty;
            authCode = string.Empty;
            try
            {
                IDB DB = new guestbookDB(@" 
insert into users(names,nick,account,password,email,role) values(@names,@nick,@account,@password,@email,@role);
set @authcode=(select authCode from users where account=@account); ");
                List<SqlParameter> paraList = new List<SqlParameter>();
                paraList.Add(new SqlParameter("name", _users.names) { SqlDbType = SqlDbType.NVarChar });
                paraList.Add(new SqlParameter("nick", _users.nick) { SqlDbType = SqlDbType.NVarChar });
                paraList.Add(new SqlParameter("account", _users.account) { SqlDbType = SqlDbType.NVarChar });
                paraList.Add(new SqlParameter("password", HashPassword(_users.password)) { SqlDbType = SqlDbType.VarChar });
                paraList.Add(new SqlParameter("email", _users.email) { SqlDbType = SqlDbType.VarChar });
                paraList.Add(new SqlParameter("role", _users.role) { SqlDbType = SqlDbType.Bit });
                paraList.Add(new SqlParameter("authcode", SqlDbType.UniqueIdentifier) { Direction = ParameterDirection.ReturnValue });
                DB.ParameterList = paraList.ToArray();
                DB.Action();
                authCode = paraList.Where(a => a.ParameterName == "authcode").FirstOrDefault().Value.ToString();
                message = @"已完成註冊";
                success = true;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                message = ex.Message;
                success = false;
            }
            return success;
        }

        //密碼Hash
        public string HashPassword(string password)
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
            bool exist = true;
            users _user = GetUserByAccount(account);
            exist = _user == null ? false : true;
            return exist;
        }

        //以帳號取得會員資料
        users GetUserByAccount(string account, bool consinderEnable=false)
        {
            users _user = null;
            try
            {
                string sql = @" select * from users where account=@account ";
                if (consinderEnable)
                    sql += @" and enabled = 1 ";
                IDB DB = new guestbookDB(sql);
                List<SqlParameter> paraList = new List<SqlParameter>();
                paraList.Add(new SqlParameter("account", account) { SqlDbType = SqlDbType.NVarChar });
                DB.ParameterList = paraList.ToArray();
                using (SqlDataReader reader = DB.GenerateReader())
                {
                    if (reader.Read())
                    {
                        _user = new users();
                        _user.account = reader["account"].ToString();
                        _user.userID = (int)reader["userID"];
                        _user.names = reader["names"].ToString();
                        _user.nick = reader["nick"].ToString();
                        _user.email = reader["email"].ToString();
                        _user.role = (int)reader["role"];
                        _user.authcode = reader["authcode"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                _user = null;
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
                if (_users.authcode.Equals(authCode))
                {
                    try
                    {
                        IDB DB = new guestbookDB(@" 
update users set validateDate=GetDate(),enabled=1 where account=@account ");
                        List<SqlParameter> paraList = new List<SqlParameter>();
                        paraList.Add(new SqlParameter("account", _users.account) { SqlDbType = SqlDbType.NVarChar });
                        DB.ParameterList = paraList.ToArray();
                        DB.Action();

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
    }
}