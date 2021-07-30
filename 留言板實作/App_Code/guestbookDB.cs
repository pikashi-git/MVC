using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 留言板實作.Interfaces;

namespace 留言板實作.App_Code
{
    public class guestbookDB: IDB
    {
        public string ErrorMsg { get; set; }
        public CommandType CommandType { get; set; }
        public string CommandText { get; set; }
        public SqlParameter[] ParameterList { get; set; }
        public string Connection { get; set; }
        public SqlConnection Conn { get; set; }
        public SqlCommand Cmd { get; set; }
        public guestbookDB(string sql, SqlParameter[] parms = null)
        {
            Connection = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["GuestBook"].ConnectionString;
            if (CommandType != CommandType.StoredProcedure && CommandType != CommandType.Text)
                CommandType = CommandType.Text;
            CommandText = sql;
            ParameterList = parms;
        }
        public void Connect()
        {
            Conn = new SqlConnection(Connection);
            if (Conn.State != ConnectionState.Open)
                Conn.Open();
        }
        public int Action()
        {
            int count = 0;
            Connect();

            using (Cmd = new SqlCommand())
            {
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if(ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                count = Cmd.ExecuteNonQuery();
            }
            DisConnect();

            return count;
        }
        public int GenerateDataSet(out DataSet ds)
        {
            int count = 0;
            ds = new DataSet();
            Connect();
            using (Cmd = new SqlCommand())
            {
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if (ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);
                count = adp.Fill(ds);
            }
            DisConnect();
            return count;
        }
        public int GenerateDataTable(out DataTable dt)
        {
            int count = 0;
            dt = new DataTable();
            Connect();
            using (Cmd = new SqlCommand())
            {
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if(ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);
                count = adp.Fill(dt);
            }
            DisConnect();
            return count;
        }
        public SqlDataReader GenerateReader()
        {
            int count = 0;
            SqlDataReader reader = null;
            Connect();
            using (Cmd = new SqlCommand())
            {
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if (ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                reader = Cmd.ExecuteReader();
            }
            DisConnect();
            return reader;
        }
        public void DisConnect()
        {
            if (Conn.State != ConnectionState.Closed)
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
    }
}