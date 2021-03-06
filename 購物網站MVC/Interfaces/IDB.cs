using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 購物網站MVC_Demo.Interfaces
{
    public interface IDB
    {
        string ErrorMsg { get; set; }
        CommandType CommandType { get; set; }
        string CommandText { get; set; } 
        SqlParameter[] ParameterList { get; set; }
        string Connection { get; set; }
        SqlConnection Conn { get; set; }
        SqlTransaction Transac { get; set; }
        SqlCommand Cmd { get; set; }
        void Connect();
        int Action();
        string ActionScalar();
        SqlDataReader ActionReader();
        int ActionDataTable(out DataTable dt);
        int ActionDataSet(out DataSet ds);
        void DisConnect();
    }
}
