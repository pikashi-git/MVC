using System;
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
            List<guestbook> guestbookList = null;

            using (SqlConnection con = new SqlConnection(constr))
            {

                string sql = string.Empty;
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql;
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                }
            }

            return guestbookList;
        }
    }
}