using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BestilVasketidCore
{
    public class DBTools
    {
        string connectionString = "Data Source=192.168.4.224;Initial Catalog=dbbestilvasketid.dk;User ID=sa;Password=Pass1234";

        //Executes a normal sql query
        public void ExecuteSQL(SqlCommand cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public int ExecuteSQLGetID(SqlCommand cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;                
                cmd.Parameters.Add(parameter);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return (int)parameter.Value;
            }
        }

        //Retrieves data from SQL as a datatable
        public DataTable SQL2Datatable(SqlCommand cmd)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dataTable);
                da.Dispose();
                return dataTable;
            }
        }

        internal int? CreateTimeStamp()
        {
            
            throw new NotImplementedException();
        }

        //Converts the datatable to list based on the item types
        public List<T> Datatable2List<T>(DataTable dt)
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                list.Add(item);
            }
            return list;
        }

        //Sets value from datatable row based on the column name
        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (System.Reflection.PropertyInfo pro in temp.GetProperties())
                {
                    //Removes the _fk from sqlDB table columns
                    string[] split = column.ColumnName.ToLower().Split("_"); 
                    //If property name = rows column name and is not DBNull, then add value
                    if (pro.Name.ToLower() == split[0] && dr[column.ColumnName] != DBNull.Value)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else continue;
                }
            }
            return obj;
        }
    }
}
