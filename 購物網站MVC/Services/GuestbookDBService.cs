using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.Models;
using System.Data;
using 購物網站MVC_Demo.Services;
using 購物網站MVC_Demo.ViewModels;
using 購物網站MVC_Demo.Interfaces;
using 購物網站MVC_Demo.App_Code;

namespace 購物網站MVC_Demo.Services
{
    public class GuestbookDBService
    {
        public GuestbookInfoViewModel GetguestbookInfoList()
        {
            List<GuestbookInfo> guestbookInfoList = new List<GuestbookInfo>();
            DataTable dt = new DataTable();

            IDB DB = new GuestbookDB(@" 
select A.*,B.names,B.nick from guestbook A inner join users B on A.userID=B.userID ");
            if (DB.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    GuestbookInfo gb = new GuestbookInfo();
                    gb.ID = (int)row["ID"];
                    gb.UserID = (int)row["userID"];
                    gb.PostContent = row["postContent"].ToString();
                    gb.Parent = (int)row["parent"];
                    gb.Createtime = (DateTime)row["createtime"];
                    gb.Names = row["names"].ToString();
                    gb.Nick = row["nick"].ToString();
                    guestbookInfoList.Add(gb);
                }
            }
            GuestbookInfoViewModel model = new GuestbookInfoViewModel();
            model.GuestbookInfoList = guestbookInfoList;
            return model;
        }

        public void InsertGuestBook(Guestbook newData)
        {
            try
            {
                IDB DB = new GuestbookDB($@" 
                insert into guestbook(userID,postContent,parent) values((select userID from users where account='{newData.User.Account}'),'{newData.PostContent}',{newData.Parent}) ");
                DB.Action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Guestbook GetGuestBook(int id)
        {
            try
            {
                Guestbook guestBook = new Guestbook();
                IDB DB = new GuestbookDB(@" 
select * from guestbook where id=@id ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("id", SqlDbType.Int) { SqlValue = id });
                DB.ParameterList = sqlParaList.ToArray();
                DataTable dt = new DataTable();
                if (DB.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
                {
                    guestBook.ID = id;
                    guestBook.UserID = (int)dt.Rows[0]["userID"];
                    guestBook.PostContent = dt.Rows[0]["postContent"].ToString();
                    guestBook.Parent = (int)dt.Rows[0]["parent"];
                    guestBook.Createtime = (DateTime)dt.Rows[0]["createtime"];
                    //取會員資料
                    IDB DBuser = new GuestbookDB(@" 
select * from users where userID=@userID ");
                    List<SqlParameter> sqlParaList1 = new List<SqlParameter>();
                    sqlParaList1.Add(new SqlParameter("userID", SqlDbType.Int) { SqlValue = guestBook.UserID });
                    DBuser.ParameterList = sqlParaList1.ToArray();
                    dt = new DataTable();
                    if (DBuser.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
                    {
                        guestBook.User = new Users
                        {
                            Account = Convert.ToString(dt.Rows[0]["account"]),
                            Email = Convert.ToString(dt.Rows[0]["email"]),
                            Names = Convert.ToString(dt.Rows[0]["names"]),
                            Nick = Convert.ToString(dt.Rows[0]["nick"]),
                            Role = dt.Rows[0]["role"].ToString(),
                            UserID = Convert.ToInt32(dt.Rows[0]["userID"])
                        };
                    }
                    return guestBook;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GuestbookInfoViewModel GetguestbookInfoList(string search, Paging page)
        {
            try
            {
                IDB DB = null;
                DataTable dt = new DataTable();
                if (!string.IsNullOrEmpty(search))
                {
                    DB = new GuestbookDB(@"
select count(*) from guestbook C inner join users D on C.userID=D.userID 
where C.userID like @search or C.postContent like @search;
 ");
                    List<SqlParameter> sqlParaList = new List<SqlParameter>();
                    sqlParaList.Add(new SqlParameter("search", SqlDbType.NVarChar) { SqlValue = '%' + search + '%' });
                    DB.ParameterList = sqlParaList.ToArray();
                    string total = DB.ActionScalar();
                    page.GeneratePage(Convert.ToInt32(total));
                    sqlParaList.Clear();

                    DB = new GuestbookDB(@"
select * from 
(
	select row_number() over (order by A.id) as 序號,A.*,B.names,B.nick 
    , (select count(*) from guestbook C inner join users D on C.userID=D.userID where C.userID like @search or C.postContent like @search) as total
	from guestbook A 
    join users B on A.userID=B.userID
    where A.userID like @search or A.postContent like @search
) t
where 序號 > (@page-1)*@item and 序號 < @page*@item + 1
 ");
                    sqlParaList.Add(new SqlParameter("search", SqlDbType.NVarChar) { SqlValue = '%' + search + '%' });
                    sqlParaList.Add(new SqlParameter("page", SqlDbType.Int) { SqlValue = page.CurrentPage });
                    sqlParaList.Add(new SqlParameter("item", SqlDbType.Int) { SqlValue = page.ItemCount });
                    DB.ParameterList = sqlParaList.ToArray();
                }
                else
                {
                    DB = new GuestbookDB(@"
select count(*) from guestbook C inner join users D on C.userID=D.userID 
 ");
                    string total = DB.ActionScalar();
                    page.GeneratePage(Convert.ToInt32(total));

                    DB = new GuestbookDB(@"
select * from 
(
	select row_number() over (order by A.id) as 序號,A.*,B.names,B.nick 
    , (select count(*) from guestbook C inner join users D on C.userID=D.userID) as total
	from guestbook A inner join users B on A.userID=B.userID
) t
where 序號 > (@page-1)*@item and 序號 < @page*@item + 1
 ");
                    List<SqlParameter> sqlParaList = new List<SqlParameter>();
                    sqlParaList.Add(new SqlParameter("page", SqlDbType.Int) { SqlValue = page.CurrentPage });
                    sqlParaList.Add(new SqlParameter("item", SqlDbType.Int) { SqlValue = page.ItemCount });
                    DB.ParameterList = sqlParaList.ToArray();
                }

                if (DB != null && DB.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
                {
                    GuestbookInfoViewModel guestBookViewModel = new GuestbookInfoViewModel();
                    List<GuestbookInfo> gbInfoList = new List<GuestbookInfo>();
                    guestBookViewModel.Search = search;
                    guestBookViewModel.Pages = page;
                    guestBookViewModel.GuestbookInfoList = gbInfoList;
                    foreach (DataRow row in dt.Rows)
                    {
                        GuestbookInfo gbInfo = new GuestbookInfo();
                        gbInfo.ID = (int)row["ID"];
                        gbInfo.UserID = (int)row["userID"];
                        gbInfo.PostContent = row["postContent"].ToString();
                        gbInfo.Parent = (int)row["parent"];
                        if (row["createtime"] != DBNull.Value)
                            gbInfo.Createtime = (DateTime)row["createtime"];
                        if (row["updatetime"] != DBNull.Value)
                            gbInfo.Updatetime = (DateTime)row["updatetime"];
                        gbInfo.Names = row["names"].ToString();
                        gbInfo.Nick = row["nick"].ToString();
                        gbInfoList.Add(gbInfo);
                    }
                    return guestBookViewModel;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateGuestBook(Guestbook data)
        {
            try
            {
                IDB DB = new GuestbookDB(@"
update guestbook set userID=@userID,postContent=@postContent,updatetime=getdate() where ID=@ID ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("userID", SqlDbType.Int) { SqlValue = data.UserID });
                sqlParaList.Add(new SqlParameter("postContent", SqlDbType.NVarChar) { SqlValue = data.PostContent });
                sqlParaList.Add(new SqlParameter("ID", SqlDbType.Int) { SqlValue = data.ID });
                DB.ParameterList = sqlParaList.ToArray();
                DB.Action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ReplyGuestBook(Guestbook data)
        {
            try
            {
                IDB DB = new GuestbookDB($@" 
insert into guestbook(userID,postContent,parent,createtime) values(@userID,@postContent,@parent,getdate()) ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("userID", SqlDbType.Int) { SqlValue = data.UserID });
                sqlParaList.Add(new SqlParameter("postContent", SqlDbType.NVarChar) { SqlValue = data.PostContent });
                sqlParaList.Add(new SqlParameter("parent", SqlDbType.Int) { SqlValue = data.Parent });
                DB.ParameterList = sqlParaList.ToArray();
                DB.Action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteGuestBook(int id)
        {
            try
            {
                IDB DB = new GuestbookDB(@"
delete from guestbook where ID=@ID ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("ID", SqlDbType.Int) { SqlValue = id });
                DB.ParameterList = sqlParaList.ToArray();
                DB.Action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}