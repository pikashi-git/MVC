﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 留言板實作.Models;
using System.Data;

namespace 留言板實作.Services
{
    public class guestbookDBService
    {
        readonly string constr = ConfigurationManager.ConnectionStrings["GuestBook"].ConnectionString;

        public List<guestbook> GetguestbookList()
        {
            List<guestbook> guestbookList = new List<guestbook>();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string sql = @" SELECT * FROM [guestbook]; ";
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    adp.Fill(dt);
                }
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    guestbook gb = new guestbook();
                    gb.ID = (int)row["ID"];
                    gb.userID = (int)row["userID"];
                    gb.postContent = row["postContent"].ToString();
                    gb.parent = (int)row["parent"];
                    gb.createtime = (DateTime)row["createtime"];
                    guestbookList.Add(gb);
                }
            }
            return guestbookList;
        }
    }
}