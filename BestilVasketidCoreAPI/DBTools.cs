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

        //Converts the datatable to list based on the item types
        public List<T> Datatable2List<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
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
                    string[] split = column.ColumnName.ToLower().Split("_"); //Removes the _fk in sqlDB table columns
                    if (pro.Name.ToLower() == split[0] && dr[column.ColumnName] != DBNull.Value)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else continue;
                }
            }
            return obj;
        }
    }
}
