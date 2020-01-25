using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;

using System.Configuration;

namespace NIT.RealTime.DBConnection
{
    /// <summary>
    /// Summary description for Connection
    /// </summary>
    public sealed class Connection
    {
        public Connection()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static string GetConnection()
        {
            
            return ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        }



        //public static Database GetDefaultDBConnection()
        //{
        //    Configure DatabaseFactory to read configuration from web.config file
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();

        //    Create default Database object from the factory.
        //     Actual concerete type is determenend by configuration Setting

        //    Database defaultDB = factory.CreateDefault();
        //    return defaultDB;
        //}
        #region this are another way to get connection string from web.config
        //public static Database GetNamedDBConnection()
        //{
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    Database namedDB = factory.Create("conStr");
        //    return namedDB;
        //}

        //public static SqlDatabase GetSqlDatabaseDefaultConnection()
        //{
        //    //configure DatabaseFactory to read configuration from web.config
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    // Create the SqlDatabase object from configuration using the default database
        //    SqlDatabase sqlServerDefaultDB = factory.CreateDefault() as SqlDatabase;
        //    return sqlServerDefaultDB;
        //}

        //public static SqlDatabase GetSqlDatabaseNamedConnection()
        //{
        //    DatabaseProviderFactory factory = new DatabaseProviderFactory();
        //    SqlDatabase sqlServerNamedDB = factory.Create("conStr") as SqlDatabase;
        //    return sqlServerNamedDB;
        //}


        //public static SqlDatabase GetSqlDBConnection()
        //{
        //    SqlDatabase sqlServerDB = new SqlDatabase(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString);
        //    return sqlServerDB;
        //}
        #endregion
    }
}