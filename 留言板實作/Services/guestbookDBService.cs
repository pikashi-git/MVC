﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 留言板實作.Models;
using System.Data;
using 留言板實作.Services;
using 留言板實作.ViewModels;

namespace 留言板實作.Services
{
    public class guestbookDBService
    {
        public guestbookInfoViewModel GetguestbookInfoList()
        {
            List<guestbookInfo> guestbookInfoList = new List<guestbookInfo>();
            DataTable dt = new DataTable();

            guestbookDB DB = new guestbookDB(@" 
select A.*,B.names,B.nick from guestbook A inner join users B on A.userID=B.userID ");
            if (DB.GenerateDataTable(out dt) > 0 && dt != null && dt.Rows.Count > 0)
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
    }
}