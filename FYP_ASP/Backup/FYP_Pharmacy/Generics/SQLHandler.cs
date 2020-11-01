using Generics.Cache;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Generics
{
    public class SQLHandler
    {
        #region Fields & Properties

        public static readonly string SQL_CONNECTION = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        public static readonly string CONTEXT = "SQLHandler";
        SqlConnection sqlConnection;
        ArrayList Params;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        public MessageCollection Messages = new MessageCollection();

        #endregion

        //Default Constructor if the Query Doesnt Require Params
        public SQLHandler()
        { }

        //Constructor if the Query Requires Params
        public SQLHandler(ArrayList Params)
        {
            this.Params = Params;
        }

        public DataTable ExecuteSqlReterieve(string query)
        {
            try
            {
                try
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection = null;
                    }
                    sqlConnection = new SqlConnection(SQL_CONNECTION);
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    Messages.addMessage(new Message()
                    {
                        Context = CONTEXT,
                        ErrorCode = ErrorCache.SqlConnectionError,
                        ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.SqlConnectionError) + ": " + ex.Message,
                        isError = true,
                    });
                }

                if (!Messages.isErrorOccured)
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        if (Params != null)
                        {
                            for (int i = 0; i < Params.Count; i++)
                            {
                                sqlCommand.Parameters.AddWithValue("arg" + i, Params[i]);
                            }
                        }


                        SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                        da.Fill(ds);
                        dt = ds.Tables[0];
                    }

                    sqlConnection.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Messages.addMessage(new Message()
                {
                    Context = CONTEXT,
                    ErrorCode = ErrorCache.GeneralSqlError,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.GeneralSqlError) + ":" + ex.Message,
                    isError = true,
                });
            }
            return null;
        }

        public bool ExecuteNonQuery(string query)
        {
            try
            {
                try
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection = null;
                    }
                    sqlConnection = new SqlConnection(SQL_CONNECTION);
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    Messages.addMessage(new Message()
                    {
                        Context = CONTEXT,
                        ErrorCode = ErrorCache.SqlConnectionError,
                        ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.SqlConnectionError) + ": " + ex.Message,
                        isError = true,
                    });
                }

                if (!Messages.isErrorOccured)
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        if (Params != null)
                        {
                            for (int i = 0; i < Params.Count; i++)
                            {
                                sqlCommand.Parameters.AddWithValue("arg" + i, Params[i]);
                            }
                        }

                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                    sqlConnection.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Messages.addMessage(new Message()
                {
                    Context = CONTEXT,
                    ErrorCode = ErrorCache.GeneralSqlError,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.GeneralSqlError) + ":" + ex.Message,
                    isError = true,
                });
            }
            return false;
        }

        public int? ExecuteScalar(string query)
        {
            try
            {
                int Id;
                try
                {
                    if (sqlConnection != null)
                    {
                        sqlConnection.Close();
                        sqlConnection = null;
                    }
                    sqlConnection = new SqlConnection(SQL_CONNECTION);
                    sqlConnection.Open();
                }
                catch (Exception ex)
                {
                    Messages.addMessage(new Message()
                    {
                        Context = CONTEXT,
                        ErrorCode = ErrorCache.SqlConnectionError,
                        ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.SqlConnectionError) + ": " + ex.Message,
                        isError = true,
                    });
                }

                if (!Messages.isErrorOccured)
                {
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        if (Params != null)
                        {
                            for (int i = 0; i < Params.Count; i++)
                            {
                                sqlCommand.Parameters.AddWithValue("arg" + i, Params[i]);
                            }
                        }

                        Id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                        sqlConnection.Close();
                    }
                    sqlConnection.Close();

                    return Id;
                }
            }
            catch (Exception ex)
            {
                Messages.addMessage(new Message()
                {
                    Context = CONTEXT,
                    ErrorCode = ErrorCache.GeneralSqlError,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.GeneralSqlError) + ":" + ex.Message,
                    isError = true,
                });
            }
            return null;
        }

    }
}
