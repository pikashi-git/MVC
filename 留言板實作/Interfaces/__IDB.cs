using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 留言板實作.Interfaces
{
    public interface IDB
    {
        public string ErrorMsg { get; set; }
        public CommandType CommandType { get; set; }
        public string CommandText { get; set; } 
        public SqlParameter[] ParameterList { get; set; }
        public string Connection { get; set; }
        public SqlConnection Conn { get; set; }
        public SqlCommand Cmd { get; set; }
        public void Connect();
        public int Action();
        public int FillDataTable(out DataTable dt);
        public int FillDataSet(out DataSet ds);
        public void DisConnect();
    }
}
