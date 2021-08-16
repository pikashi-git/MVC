using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 留言板實作.Models;
using System.Data;
using 留言板實作.Services;
using 留言板實作.ViewModels;
using 留言板實作.Interfaces;
using 留言板實作.App_Code;

namespace 留言板實作.Services
{
    public class guestbookDBService
    {
        public guestbookInfoViewModel GetguestbookInfoList()
        {
            List<guestbookInfo> guestbookInfoList = new List<guestbookInfo>();
            DataTable dt = new DataTable();

            IDB DB = new guestbookDB(@" 
select A.*,B.names,B.nick from guestbook A inner join users B on A.userID=B.userID ");
            if (DB.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    guestbookInfo gb = new guestbookInfo();
                    gb.ID = (int)row["ID"];
                    gb.userID = (int)row["userID"];
                    gb.postContent = row["postContent"].ToString();
                    gb.parent = (int)row["parent"];
                    gb.createtime = (DateTime)row["createtime"];
                    gb.names = row["names"].ToString();
                    gb.nick = row["nick"].ToString();
                    guestbookInfoList.Add(gb);
                }
            }
            guestbookInfoViewModel model = new guestbookInfoViewModel();
            model.guestbookInfoList = guestbookInfoList;
            return model;
        }

        public void InsertGuestBook(guestbook newData)
        {
            try
            {
                IDB DB = new guestbookDB($@" 
insert into guestbook(userID,postContent,parent) values('{newData.userID}','{newData.postContent}',{newData.parent}) ");
                DB.Action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public guestbook GetGuestBook(int id)
        {
            try
            {
                guestbook guestBook = new guestbook();
                IDB DB = new guestbookDB(@" 
select * from guestbook where id=@id ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("id", SqlDbType.Int) { SqlValue = id });
                DB.ParameterList = sqlParaList.ToArray();
                DataTable dt = new DataTable();
                if (DB.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
                {
                    guestBook.ID = id;
                    guestBook.userID = (int)dt.Rows[0]["userID"];
                    guestBook.postContent = dt.Rows[0]["postContent"].ToString();
                    guestBook.parent = (int)dt.Rows[0]["parent"];
                    guestBook.createtime = (DateTime)dt.Rows[0]["createtime"];

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

        public guestbookInfoViewModel GetguestbookInfoList(string search, Paging page)
        {
            try
            {
                IDB DB = null;
                if (!string.IsNullOrEmpty(search))
                {
                    DB = new guestbookDB(@"
select * from 
(
	select row_number() over (order by A.id) as 序號,A.*,B.names,B.nick 
    , (select count(*) from guestbook C inner join users D on C.userID=D.userID where C.userID like @search or C.postContent like @search) as total
	from guestbook A inner join users B on A.userID=B.userID
    where A.userID like @search or A.postContent like @search
) t
where 序號 > (@page-1)*@item and 序號 < @page*@item + 1
 ");
                    List<SqlParameter> sqlParaList = new List<SqlParameter>();
                    sqlParaList.Add(new SqlParameter("search", SqlDbType.NVarChar) { SqlValue = '%' + search + '%' });
                    sqlParaList.Add(new SqlParameter("page", SqlDbType.Int) { SqlValue = page.CurrentPage });
                    sqlParaList.Add(new SqlParameter("item", SqlDbType.Int) { SqlValue = page.ItemCount });
                    DB.ParameterList = sqlParaList.ToArray();
                }
                else
                {
                    DB = new guestbookDB(@"
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

                DataTable dt = new DataTable();
                if (DB != null && DB.ActionDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
                {
                    //頁次
                    page.GeneratePage((int)dt.Rows[0]["total"]);

                    guestbookInfoViewModel guestBookViewModel = new guestbookInfoViewModel();
                    List<guestbookInfo> gbInfoList = new List<guestbookInfo>();
                    guestBookViewModel.Search = search;
                    guestBookViewModel.pages = page;
                    guestBookViewModel.guestbookInfoList = gbInfoList;
                    foreach (DataRow row in dt.Rows)
                    {
                        guestbookInfo gbInfo = new guestbookInfo();
                        gbInfo.ID = (int)row["ID"];
                        gbInfo.userID = (int)row["userID"];
                        gbInfo.postContent = row["postContent"].ToString();
                        gbInfo.parent = (int)row["parent"];
                        if (row["createtime"] != DBNull.Value)
                            gbInfo.createtime = (DateTime)row["createtime"];
                        if (row["updatetime"] != DBNull.Value)
                            gbInfo.updatetime = (DateTime)row["updatetime"];
                        gbInfo.names = row["names"].ToString();
                        gbInfo.nick = row["nick"].ToString();
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

        public void UpdateGuestBook(guestbook data)
        {
            try
            {
                IDB DB = new guestbookDB(@"
update guestbook set userID=@userID,postContent=@postContent,updatetime=getdate() where ID=@ID ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("userID", SqlDbType.Int) { SqlValue = data.userID });
                sqlParaList.Add(new SqlParameter("postContent", SqlDbType.NVarChar) { SqlValue = data.postContent });
                sqlParaList.Add(new SqlParameter("ID", SqlDbType.Int) { SqlValue = data.ID });
                DB.ParameterList = sqlParaList.ToArray();
                DB.Action();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ReplyGuestBook(guestbook data)
        {
            try
            {
                IDB DB = new guestbookDB($@" 
insert into guestbook(userID,postContent,parent,createtime) values(@userID,@postContent,@parent,getdate()) ");
                List<SqlParameter> sqlParaList = new List<SqlParameter>();
                sqlParaList.Add(new SqlParameter("userID", SqlDbType.Int) { SqlValue = data.userID });
                sqlParaList.Add(new SqlParameter("postContent", SqlDbType.NVarChar) { SqlValue = data.postContent });
                sqlParaList.Add(new SqlParameter("parent", SqlDbType.Int) { SqlValue = data.parent });
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
                IDB DB = new guestbookDB(@"
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