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
        string ErrorMsg { get; set; }
        CommandType CommandType { get; set; }
        string CommandText { get; set; } 
        SqlParameter[] ParameterList { get; set; }
        string Connection { get; set; }
        SqlConnection Conn { get; set; }
        SqlCommand Cmd { get; set; }
        void Connect();
        int Action();
        int FillDataTable(out DataTable dt);
        int FillDataSet(out DataSet ds);
        void DisConnect();
    }
}
