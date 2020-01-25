using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//using System.Data;
//using System.Data.SqlClient;
//using NIT.RealTime.DAL;
//using NIT.RealTime.DBConnection;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NIT.RealTime.Common;
using NIT.RealTime.DBConnection;
using System.Data.SqlClient;
using NIT.RealTime.DAL;

namespace NIT.RealTime.BLL
{
    public class Emp : Dept
    {
        #region Class Private Data
        private int _empId;
        private string _empName;
        private string _empJob;
        private decimal _empSalary;
        #endregion

        #region Default Constructor
        public Emp()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion

        #region Public Properties
        public int EmpId
        {
            get { return this._empId; }
            set { this._empId = value; }
        }

        public string EmpName
        {
            get { return this._empName; }
            set { this._empName = value; }
        }

        public string EmpJob
        {
            get { return this._empJob; }
            set { this._empJob = value; }
        }

        public decimal EmpSalary
        {
            get { return this._empSalary; }
            set { this._empSalary = value; }
        }
        public int DeptId
        {
            get { return this._deptId; }
            set { this._deptId = value; }
        }
        #endregion

        #region class Public Method

        #region GetEmployeeData()
        public DataSet GetEmployeeData()
        {
            strSqlCommand = "select e.EmpId, e.EmpName, e.EmpJob, e.EmpSalary, e.DId, d.DeptName from emp e, dept d where e.DId=D.DeptId";
            return SqlHelper.ExexuteDataSet(strSqlCommand, Connection.GetConnection());
            //strSqlCommand = "SP_GetEmployeeData";
            //return SqlHelper.ExexuteDataSet(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection());
        }

        //public DataSet GetEmployeeData()
        //{
        //    Database defaultDB = Connection.GetDefaultDBConnection();
        //    strSqlCommand = "select e.EmpId, e.EmpName, e.EmpJob, e.EmpSalary, e.DId, d.DeptName from emp e, dept d where e.DId=D.DeptId";
        //    DbCommand dbCommand = defaultDB.GetSqlStringCommand(strSqlCommand);
        //    return defaultDB.ExecuteDataSet(dbCommand);
        //}
        #endregion

        #region InsertEmployeeData (without parameter)
        public int InsertEmployeeData()
        {
            strSqlCommand = "insert into Emp (EmpName,EmpJob,EmpSalary,DId) values (@empName,@empJob,@empSalary,@deptId)";
            //strSqlCommand = "SP_InsertEmployeeData";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@empName",this._empName),
                new SqlParameter("@empJob",this._empJob),
                new SqlParameter("@empSalary",this._empSalary),
                new SqlParameter("@deptId",this._deptId)
            };
            return SqlHelper.ExecuteNonQuery(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), parameters);
        }
        //public int InsertEmployeeData()
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = "insert into Emp (EmpName,EmpJob,EmpSalary,DId) values ('" + this._empName + "','" + this._empJob + "'," + this._empSalary + "," + this._deptId + ")";
        //    strSqlCommand = "insert into Emp (EmpName,EmpJob,EmpSalary,DId) values (@empName,@empJob,@empSalary,@deptId)";
        //    strSqlCommand = "SP_InsertEmployeeData";
        //    DbCommand dbCommand = defaultDb.GetStoredProcCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@empName", DbType.AnsiString, this._empName);
        //    defaultDb.AddInParameter(dbCommand, "@empJob", DbType.AnsiString, this._empJob);
        //    defaultDb.AddInParameter(dbCommand, "@empSalary", DbType.Currency, this._empSalary);
        //    defaultDb.AddInParameter(dbCommand, "@deptId", DbType.Int32, this._deptId);
        //    return defaultDb.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        #region InsertEmployeeData (With Parameter)
        public int InsertEmployeeData(string empName, string empJob, decimal empSalary, int deptId)
        {
            //strSqlCommand = "insert into Emp (EmpName,EmpJob,EmpSalary,DId) values (@empName,@empJob,@empSalary,@deptId)";
            strSqlCommand = "SP_InsertEmployeeData";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@empName",empName),
                new SqlParameter("@empJob",empJob),
                new SqlParameter("@empSalary",empSalary),
                new SqlParameter("@deptId",deptId)
            };
            return SqlHelper.ExecuteNonQuery(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), parameters);
        }



        // public int InsertEmployeeData(string empName, string empJob, decimal empSalary, int deptId)
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        ////    strSqlCommand = strSqlCommand = "insert into Emp (EmpName,EmpJob,EmpSalary,DId) values ('" +empName + "','" + empJob + "'," + empSalary + "," + deptId + ")";
        //    //strSqlCommand = "insert into Emp (EmpName,EmpJob,EmpSalary,DId) values (@empName,@empJob,@empSalary,@deptId)";
        //    strSqlCommand = "SP_InsertEmployeeData";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@empName", DbType.AnsiString, empName);
        //    defaultDb.AddInParameter(dbCommand, "@empJob", DbType.AnsiString, empJob);
        //    defaultDb.AddInParameter(dbCommand, "@empSalary", DbType.Currency,empSalary);
        //    defaultDb.AddInParameter(dbCommand, "@deptId", DbType.Int32, deptId);
        //    return defaultDb.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        #region GetEmployeeDetails
        public DataSet GetEmployeeDetails()
        {
            //strSqlCommand = "Select * from Emp where EmpId= @EmpId";
            strSqlCommand = "SP_GetEmployeeDetails";
            return SqlHelper.ExexuteDataSet(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), new SqlParameter("@EmpId", this._empId));
        }

        //public DataSet GetEmployeeDetails()
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = "Select * from Emp where EmpId= @EmpId";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@EmpId", DbType.Int32, this._empId);
        //    return defaultDb.ExecuteDataSet(dbCommand);
        //}
        #endregion

        #region GetEmployeeDetails with parameter
        public DataSet GetEmployeeDetails(int empId)
        {
            //strSqlCommand = "Select * from Emp where EmpId=@EmpId";
            strSqlCommand = "SP_GetEmployeeDetails";
            return SqlHelper.ExexuteDataSet(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), new SqlParameter("@EmpId", empId));
        }

        //public DataSet GetEmployeeDetails(int empId)
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = "Select * from Emp where EmpId= @EmpId";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@EmpId", DbType.Int32, empId);
        //    return defaultDb.ExecuteDataSet(dbCommand);
        //}
        #endregion

        #region UpdateEmployeeData (Without parameter)
        public int UpdateEmployeeData()
        {
            //strSqlCommand = "update emp set EmpName = @empName, EmpJob = @empJob, EmpSalary = @empSalary, DId = @deptId where EmpId = @empId";
            strSqlCommand = "SP_UpdateEmployeeData";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@empName",this._empName),
                new SqlParameter("@empJob",this._empJob),
                new SqlParameter("@empSalary",this._empSalary),
                new SqlParameter("@deptId",this._deptId),
                new SqlParameter("@empId",this._empId)
            };
            return SqlHelper.ExecuteNonQuery(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), parameters);
        }

        //public int UpdateEmployeeData()
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = "update emp set EmpName = @empName, EmpJob = @empJob, EmpSalary = @empSalary, DId = @deptId where EmpId = @empId";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@empName", DbType.AnsiString, this._empName);
        //    defaultDb.AddInParameter(dbCommand, "@empJob", DbType.AnsiString, this._empJob);
        //    defaultDb.AddInParameter(dbCommand, "@empSalary", DbType.Currency, this._empSalary);
        //    defaultDb.AddInParameter(dbCommand, "@deptId", DbType.Int32, this._deptId);
        //    defaultDb.AddInParameter(dbCommand, "@empId", DbType.Int32, this._empId);

        //    return defaultDb.ExecuteNonQuery(dbCommand);
        //}

        #endregion

        #region  UpdateEmployeeData (with parameters
        public int UpdateEmployeeData(int EmpId, string EmpName, string EmpJob, decimal EmpSalary, int DeptId)
        {
            //strSqlCommand = "update emp set EmpName = @empName, EmpJob = @empJob, EmpSalary = @empSalary, DId = @deptId where EmpId = @empId";
            strSqlCommand = "SP_UpdateEmployeeData";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@empId",EmpId),
                new SqlParameter("@empName",EmpName),
                new SqlParameter("@empJob",EmpJob),
                new SqlParameter("@empSalary",EmpSalary),
                new SqlParameter("@deptId",DeptId)
            };
            return SqlHelper.ExecuteNonQuery(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), parameters);
        }

        //public int UpdateEmployeeData(int EmpId, string EmpName, string EmpJob, decimal EmpSalary, int DeptId)
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = "update emp set EmpName = @empName, EmpJob = @empJob, EmpSalary = @empSalary, DId = @deptId where EmpId = @empId";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@empName", DbType.AnsiString, EmpName);
        //    defaultDb.AddInParameter(dbCommand, "@empJob", DbType.AnsiString, EmpJob);
        //    defaultDb.AddInParameter(dbCommand, "@empSalary", DbType.Currency, EmpSalary);
        //    defaultDb.AddInParameter(dbCommand, "@deptId", DbType.Int32, DeptId);
        //    defaultDb.AddInParameter(dbCommand, "@empId", DbType.Int32, EmpId);

        //    return defaultDb.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        #region Delete Employee (without parameter)
        public int DeleteEmployeeData()
        {
            //strSqlCommand = " delete emp where EmpId= @empId";
            strSqlCommand = "SP_DeleteEmployeeData";
            return SqlHelper.ExecuteNonQuery(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), new SqlParameter("@empId", this._empId));
        }

        //public int DeleteEmployeeData()
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = " delete emp where EmpId= @empId";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@empId", DbType.Int32, this._empId);
        //    return defaultDb.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        #region Delete Employee (with parameter)
        public int DeleteEmployeeData(int EmpId)
        {
            //strSqlCommand = " delete emp where EmpId= @empId";
            strSqlCommand = "SP_DeleteEmployeeData";
            return SqlHelper.ExecuteNonQuery(strSqlCommand, CommandType.StoredProcedure, Connection.GetConnection(), new SqlParameter("@empId", EmpId));
        }


        //public int DeleteEmployeeData(int EmpId)
        //{
        //    Database defaultDb = Connection.GetDefaultDBConnection();
        //    strSqlCommand = " delete emp where EmpId= @empId";
        //    DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
        //    defaultDb.AddInParameter(dbCommand, "@empId", DbType.Int32, EmpId);
        //    return defaultDb.ExecuteNonQuery(dbCommand);
        //}
        #endregion

        #endregion
    }
}