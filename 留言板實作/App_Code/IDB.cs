using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 留言板實作.App_Code
{
    interface IDB
    {
        public string ErrorMsg { get; set; }
        public CommandType CommandType { get; set; }
        public string CommandText { get; set; } 
        public SqlParameter[] ParameterList { get; set; }
        public void Connect();
        public bool Action();
        public DataTable FillDataTable();
        public DataSet FillDataSet();
        public void DisConnect();
    }
}
