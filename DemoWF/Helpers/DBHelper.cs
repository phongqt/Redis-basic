using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoWF.Helpers
{
    public static class DBHelper
    {

        /// <summary>
        /// Connection string to AOR database
        /// </summary>
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["Notification"].ConnectionString;

        /// <summary>
        /// get the connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            if (connection != null && connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        /// <summary>
        /// Query one item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T QueryItem<T>(string storeProcedureName, bool isStoreProcedure = true, params SqlParameter[] parameters)
            where T : new()
        {
            var result = Query<T>(storeProcedureName, isStoreProcedure, parameters).FirstOrDefault();
            return result;
        }


        /// <summary>
        /// Query a list of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static List<T> Query<T>(string storeProcedureName, bool isStoreProcedure = true, params SqlParameter[] parameters)
            where T : new()
        {
            var result = new List<T>();

            using (var connection = GetConnection())
            {
                using (var reader = ExecuteReader(connection, storeProcedureName, isStoreProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        var item = GetData<T>(reader);
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Query a list of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static T QueryValue<T>(string storeProcedureName, bool isStoreProcedure = true, params SqlParameter[] parameters)
        {
            var result = default(T);

            using (var connection = GetConnection())
            {
                using (var reader = ExecuteReader(connection, storeProcedureName, isStoreProcedure, parameters))
                {
                    while (reader.Read() && reader.FieldCount > 0)
                    {
                        var item = reader[0];
                        result = GetValue<T>(item);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Query a list of item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static List<T> QueryListValue<T>(string storeProcedureName, bool isStoreProcedure = true, params SqlParameter[] parameters)
        {
            var result = new List<T>();

            using (var connection = GetConnection())
            {
                using (var reader = ExecuteReader(connection, storeProcedureName, isStoreProcedure, parameters))
                {
                    while (reader.Read() && reader.FieldCount > 0)
                    {
                        var item = reader[0];
                        result.Add(GetValue<T>(item));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="storeProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(
                                SqlConnection connection,
                                string storeProcedureName, bool isStoreProcedure = true,
                                params SqlParameter[] parameters)
        {
            var command = GetCommand(connection, storeProcedureName, isStoreProcedure, parameters);
            return command.ExecuteReader();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int ExecuteNonQuery(string storeProcedureName, bool isStoreProcedure = true, params SqlParameter[] parameters)
        {
            int result;

            using (var connection = GetConnection())
            {
                var command = GetCommand(connection, storeProcedureName, isStoreProcedure, parameters);
                result = command.ExecuteNonQuery();
            }

            return result;
        }


        /// <summary>
        /// Get command
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="storeProcedureName"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static SqlCommand GetCommand(SqlConnection connection, string storeProcedureName, bool isStoreProcedure = true, params SqlParameter[] parameters)
        {
            var command = new SqlCommand(storeProcedureName, connection)
            {
                CommandType = isStoreProcedure ? CommandType.StoredProcedure : CommandType.Text
            };

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }


        /// extension for reader
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string GetString(this SqlDataReader reader, string fieldName)
        {
            var ordinal = reader.GetOrdinal(fieldName);
            return reader.GetString(ordinal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static int GetInt(this SqlDataReader reader, string fieldName)
        {
            var ordinal = reader.GetOrdinal(fieldName);
            return reader.GetInt32(ordinal);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static byte[] GetBytes(this SqlDataReader reader, string fieldName)
        {
            var ordinal = reader.GetOrdinal(fieldName);
            return reader.GetSqlBytes(ordinal).Buffer.Clone() as byte[];
        }


        /// <summary>
        /// Get data reader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static T GetData<T>(SqlDataReader dataReader) where T : new()
        {
            var result = new T();
            AssignProperties(result, dataReader);
            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="dataReader"></param>
        public static void AssignProperties<T>(T data, SqlDataReader dataReader)
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var propertyName = property.Name.ToUpper();
                var schemaTable = dataReader.GetSchemaTable();


                if (schemaTable != null)
                {
                    var colNames = schemaTable.Rows.Cast<DataRow>().Select
                        (row => row["ColumnName"] as string).ToList();

                    if (colNames.Any(r => r.ToUpper() == propertyName))
                    {
                        try
                        {
                            var propertyValue = dataReader[propertyName];

                            if (propertyValue != null
                                && propertyValue != DBNull.Value)
                            {
                                var value = GetValue(propertyValue, propertyType);
                                property.SetValue(data, value);
                            }
                        }
                        catch (Exception exception)
                        {
                            
                        }
                    }
                }
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        private static T GetValue<T>(object propertyValue)
        {
            return (T)GetValue(propertyValue, typeof(T));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyValue"></param>
        /// <param name="propertyType"></param>
        /// <returns></returns>
        private static object GetValue(object propertyValue, Type propertyType)
        {
            object value = null;

            if (propertyType == typeof(int) || propertyType == typeof(int?))
            {
                value = Convert.ToInt32(propertyValue);
            }
            else if (propertyType == typeof(bool) || propertyType == typeof(bool?))
            {
                value = Convert.ToBoolean(propertyValue);
            }
            else if (propertyType == typeof(string))
            {
                value = Convert.ToString(propertyValue);
            }
            else if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
            {
                value = Convert.ToDateTime(propertyValue);
            }
            else if (propertyType == typeof(double) || propertyType == typeof(double?))
            {
                value = Convert.ToDouble(propertyValue);
            }
            else if (propertyType == typeof(char) || propertyType == typeof(char?))
            {
                value = Convert.ToChar(propertyValue);
            }
            else if (propertyType == typeof(decimal) || propertyType == typeof(decimal?))
            {
                value = Convert.ToDecimal(propertyValue);
            }
            else if (propertyType == typeof(byte[]))
            {
                value = propertyValue;
            }
            else if (propertyType == typeof(Int64) || propertyType == typeof(Int64?))
            {
                value = Convert.ToInt64(propertyValue);
            }

            return value;
        }

        /// <summary>
        /// Bulk insert data into datatable into table of SQL Server
        /// </summary>
        public static bool BulkInsertIntoSql(string tableName, DataTable dataTable)
        {
            var returnResult = false;

            using (SqlConnection connection = GetConnection())
            {
                // make sure to enable triggers
                // more on triggers in next post
                SqlBulkCopy bulkCopy =
                    new SqlBulkCopy
                    (
                        connection,
                        SqlBulkCopyOptions.TableLock |
                        SqlBulkCopyOptions.FireTriggers |
                        SqlBulkCopyOptions.UseInternalTransaction,
                        null
                    );

                // set the destination table name
                bulkCopy.DestinationTableName = tableName;
                //connection.Open();

                // write the data in the "dataTable"
                bulkCopy.WriteToServer(dataTable);
                connection.Close();

                returnResult = true;
            }

            return returnResult;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }

            return table;
        }
    }
}
