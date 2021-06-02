using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 留言板實作.App_Code
{
    public class guestbookDB : IDB
    {
        public string ErrorMsg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CommandType CommandType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string CommandText { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public SqlParameter[] ParameterList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Action()
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void DisConnect()
        {
            throw new NotImplementedException();
        }

        public DataSet FillDataSet()
        {
            throw new NotImplementedException();
        }

        public DataTable FillDataTable()
        {
            throw new NotImplementedException();
        }
    }
}