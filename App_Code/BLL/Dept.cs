using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using System.Data;

//using NIT.RealTime.DBConnection;
////using NIT.RealTime.DAL;
//using NIT.RealTime.Common;


using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NIT.RealTime.DBConnection;
using NIT.RealTime.Common;
using NIT.RealTime.DAL;

namespace NIT.RealTime.BLL
{
    public class Dept : Utility
    {

        #region Class Protected Fields
        protected int _deptId;
        protected string _deptName;
        #endregion

        #region Default Constructor
        public Dept()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Class Public Properties
        public int DeptId
        {
            get { return _deptId; }
            set { this._deptId = value; }
        }

        public string DeptName
        {
            get { return _deptName; }
            set { this._deptName = value; }
        }
        #endregion

        #region Class Public Method
        public DataSet GetDeptData()
        {
            // strSqlCommand = "select * from dept";
            strSqlCommand = "SP_GetDeptData";
            return SqlHelper.ExexuteDataSet(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection());
            //return SqlHelper.ExexuteDataSet(strSqlCommand, Connection.GetConnection());
        }
        #endregion

        #region Class public Method Using Enterprise Library
        //public DataSet GetDeptData()
        //{
        //    Database defaultDB = Connection.GetDefaultDBConnection();
        //    //prepare inline SqlCommand
        //    strSqlCommand = "select * from dept";
        //    DbCommand dbCommand = defaultDB.GetSqlStringCommand(strSqlCommand);
        //    //DbCommand dbCommand = defaultDB.GetStoredProcCommand(strSqlCommand);
        //    return defaultDB.ExecuteDataSet(dbCommand);
        //}
        #endregion
    }
}