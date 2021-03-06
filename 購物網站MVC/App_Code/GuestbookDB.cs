using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using 購物網站MVC_Demo.Interfaces;

namespace 購物網站MVC_Demo.App_Code
{
    public class GuestbookDB: IDB
    {
        public string ErrorMsg { get; set; }
        public CommandType CommandType { get; set; }
        public string CommandText { get; set; }
        public SqlParameter[] ParameterList { get; set; }
        public string Connection { get; set; }
        public SqlConnection Conn { get; set; }
        public SqlTransaction Transac { get; set; }
        public SqlCommand Cmd { get; set; }
        public GuestbookDB(string sql, SqlParameter[] parms = null)
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

            using (Transac = Conn.BeginTransaction())
            {
                using (Cmd = Conn.CreateCommand())
                {
                    Cmd.Connection = Conn;
                    Cmd.Transaction = Transac;
                    Cmd.CommandType = CommandType;
                    Cmd.CommandText = CommandText;
                    if (ParameterList != null)
                        Cmd.Parameters.AddRange(ParameterList);
                    count = Cmd.ExecuteNonQuery();
                    if (count > 0)
                        Transac.Commit();
                    else
                        Transac.Rollback();
                }
            }

            DisConnect();
            return count;
        }
        public string ActionScalar()
        {
            string result = null;
            Connect();

            using (Cmd = Conn.CreateCommand())
            {
                Cmd.Connection = Conn;
                //Cmd.Transaction = Transac;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if (ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                result = Cmd.ExecuteScalar().ToString();
            }

            DisConnect();
            return result;
        }
        public int ActionDataSet(out DataSet ds)
        {
            int count = 0;
            ds = new DataSet();
            Connect();
            using (Cmd = Conn.CreateCommand())
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
        public int ActionDataTable(out DataTable dt)
        {
            int count = 0;
            dt = new DataTable();
            Connect();
            using (Cmd = Conn.CreateCommand())
            {
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if (ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                SqlDataAdapter adp = new SqlDataAdapter(Cmd);
                count = adp.Fill(dt);
            }

            DisConnect();
            return count;
        }
        public SqlDataReader ActionReader()
        {
            SqlDataReader reader = null;
            Connect();

            using (Cmd = Conn.CreateCommand())
            {
                Cmd.Connection = Conn;
                Cmd.CommandType = CommandType;
                Cmd.CommandText = CommandText;
                if (ParameterList != null)
                    Cmd.Parameters.AddRange(ParameterList);
                reader = Cmd.ExecuteReader();
            }

            //DisConnect();
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