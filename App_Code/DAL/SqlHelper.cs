using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace NIT.RealTime.DAL
{

        /// <summary>
        /// Summary description for SqlHelper
        /// </summary>
        public sealed class SqlHelper
        {
            #region Static Class Field
                static SqlConnection connection = null;
                static SqlCommand command = null;
                static SqlDataAdapter dataAdapter = null;
                static DataSet dataSet = null;
            #endregion

            #region Default Public Constructors
                public SqlHelper()
                {
                    //
                    // TODO: Add constructor logic here
                    //
                }
            #endregion

            #region Private Static Methods
                private static void CreateConnection(string connectionString)
                {
                    connection = new SqlConnection(connectionString);  
                }
            #endregion

            #region Public Static Methods
                public static DataSet ExexuteDataSet(string CommandText,string connectionString )
                {
                    CreateConnection(connectionString);
                    dataAdapter = new SqlDataAdapter(CommandText, connection);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }

                public static DataSet ExexuteDataSet(string CommandText, CommandType commandType, string connectionString)
                {
                    CreateConnection(connectionString);
                    dataAdapter = new SqlDataAdapter(CommandText, connection);
                    dataAdapter.SelectCommand.CommandType = commandType;
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }

                public static DataSet ExexuteDataSet(string CommandText, CommandType commandType, string connectionString,SqlParameter sqlParameter)
                {
                    CreateConnection(connectionString);
                    dataAdapter = new SqlDataAdapter(CommandText, connection);
                    dataAdapter.SelectCommand.CommandType = commandType;
                    dataAdapter.SelectCommand.Parameters.Add(sqlParameter);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }

                public static DataSet ExexuteDataSet(string CommandText, CommandType commandType, string connectionString, SqlParameter[] sqlParameter)
                {
                    CreateConnection(connectionString);
                    dataAdapter = new SqlDataAdapter(CommandText, connection);
                    dataAdapter.SelectCommand.CommandType = commandType;
                    dataAdapter.SelectCommand.Parameters.AddRange(sqlParameter);
                    dataSet = new DataSet();
                    dataAdapter.Fill(dataSet);
                    return dataSet;
                }


                public static int ExecuteNonQuery(string CommandText, string connectionString)
                {
                    CreateConnection(connectionString);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    command = new SqlCommand(CommandText,connection);
                    int rowAffected = command.ExecuteNonQuery();
                    connection.Close();
                    return rowAffected;
                }
                public static int ExecuteNonQuery(string CommandText, CommandType commandType, string connectionString)
                {
                    CreateConnection(connectionString);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    command = new SqlCommand(CommandText, connection);
                    command.CommandType = commandType;
                    int rowAffected = command.ExecuteNonQuery();
                    connection.Close();
                    return rowAffected;
                }
                public static int ExecuteNonQuery(string CommandText, CommandType commandType, string connectionString, SqlParameter sqlParameter)
                {
                    CreateConnection(connectionString);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    command = new SqlCommand(CommandText, connection);
                    command.CommandType = commandType;
                    command.Parameters.Add(sqlParameter);
                    int rowAffected = command.ExecuteNonQuery();
                    connection.Close();
                    return rowAffected;
                }
                public static int ExecuteNonQuery(string CommandText, CommandType commandType, string connectionString, SqlParameter[] sqlParameter)
                {
                    CreateConnection(connectionString);
                    if (connection.State != ConnectionState.Open)
                        connection.Open();
                    command = new SqlCommand(CommandText, connection);
                    command.CommandType = commandType;
                    command.Parameters.AddRange(sqlParameter);
                    int rowAffected = command.ExecuteNonQuery();
                    connection.Close();
                    return rowAffected;
                }
            #endregion
        }
}