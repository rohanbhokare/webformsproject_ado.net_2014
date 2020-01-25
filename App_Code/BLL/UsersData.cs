using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using NIT.RealTime.Common;
using NIT.RealTime.DBConnection;

namespace NIT.RealTime.BLL
{
    /// <summary>
    /// Summary description for UsersData
    /// </summary>
    public class UsersData : Utility
    {
        #region Class Private Fields
        int _userId;
        string _firstName;
        string _middleName;
        string _lastName;
        string _gender;
        string _dateOfBirth;
        string _emailId;
        string _password;
        bool _isActive;
        DateTime _dateOfRegistration;
        #endregion

        #region Class Public Properties
        public int UserId
        {
            get { return this._userId; }
            set { this._userId = value; }
        }
        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }
        public string MiddleName
        {
            get { return this._middleName; }
            set { this._middleName = value; }
        }
        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }
        public string Gender
        {
            get { return this._gender; }
            set { this._gender = value; }
        }
        public string DateOfBirth
        {
            get { return this._dateOfBirth; }
            set { this._dateOfBirth = value; }
        }
        public string EmailId
        {
            get { return this._emailId; }
            set { this._emailId = value; }
        }
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }
        public bool IsActive
        {
            get { return this._isActive; }
            set { this._isActive = value; }
        }
        public DateTime DateOfRegistration
        {
            get { return this._dateOfRegistration; }
            set { this._dateOfRegistration = value; }
        }

        #endregion
        public UsersData()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Public Methods
        public int UserRegistration()
        {
            Database defaultDb = Connection.GetDefaultDBConnection();
            strSqlCommand = "insert into registration (FirstName, MiddleName, LastName, Gender, DateOfBirth, EmailId,Password,IsActive,DateOfregistration) values(@FirstName, @MiddleName, @LastName, @Gender, @DateOfBirth, @EmailId,@Password,@IsActive,@DateOfregistration)";
            DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
            defaultDb.AddInParameter(dbCommand, "@FirstName", DbType.String, this._firstName);
            defaultDb.AddInParameter(dbCommand, "@MiddleName", DbType.String, this._middleName);
            defaultDb.AddInParameter(dbCommand, "@LastName", DbType.String, this._lastName);
            defaultDb.AddInParameter(dbCommand, "@Gender", DbType.String, this._gender);
            defaultDb.AddInParameter(dbCommand, "@DateOfBirth", DbType.String, this._dateOfBirth);
            defaultDb.AddInParameter(dbCommand, "@EmailId", DbType.String, this._emailId);
            defaultDb.AddInParameter(dbCommand, "@Password", DbType.String, this._password);
            defaultDb.AddInParameter(dbCommand, "@IsActive", DbType.Byte, this._isActive);
            defaultDb.AddInParameter(dbCommand, "@DateOfRegistration", DbType.DateTime, this._dateOfRegistration);
            return defaultDb.ExecuteNonQuery(dbCommand);

        }
        public int ActivateAccount()
        {
            Database defaultDb = Connection.GetDefaultDBConnection();
            strSqlCommand = "Update registration set IsActive='true' where EmailId=@EmailId";
            DbCommand dbCommand = defaultDb.GetSqlStringCommand(strSqlCommand);
            defaultDb.AddInParameter(dbCommand, "@EmailId", DbType.String, this._emailId);
            return defaultDb.ExecuteNonQuery(dbCommand);
        }
        #endregion
    }
}