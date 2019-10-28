using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BestilVasketidCoreAPI.Models;

namespace BestilVasketidCoreAPI
{
    public class DBTools
    {
        //string connectionString = "Data Source=192.168.4.224;Initial Catalog=dbbestilvasketid.dk;User ID=sa;Password=Pass1234";
        //string connectionString = "Data Source=.;Initial Catalog=dbbestilvasketid.dk;User ID=sa;Password=Pass1234";
        string connectionString = @"Data Source = sql.freeasphost.net\MSSQL2016;Initial Catalog = bestilvasketid_db; Persist Security Info=True;User ID = bestilvasketid; Password=Pass1234";

        #region Timestamp
        internal TimeStamp GetTimeStamp(int? id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [timestamp] WHERE id = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = id;

            DataTable dataTable = SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return Datatable2List<TimeStamp>(dataTable)[0];
            else return null;
        }

        internal int CreateTimeStamp()
        {
            SqlCommand cmd = new SqlCommand($"INSERT INTO [timestamp] (created) OUTPUT INSERTED.id VALUES (@timestamp)");
            cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
            return ExecuteSQLGetID(cmd);
        }

        internal void ChangeTimeStamp(int id)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE [timestamp] SET changed = @timestamp WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
            ExecuteSQL(cmd);
        }

        //Updates timestamp with delete datetime
        internal void SetDeleteTimeStamp(int id)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE [timestamp] SET deleted = @timestamp WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@timestamp", DateTime.Now);
            ExecuteSQL(cmd);
        }

        //Deletes timestamp completely
        internal int DeleteTimeStamp(int id)
        {
            SqlCommand cmd = new SqlCommand($"DELETE FROM [timestamp] WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            return ExecuteSQL(cmd);
        }
        #endregion

        internal int ExecuteSQL(SqlCommand cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();

                return cmd.ExecuteNonQuery(); //Returns rows changed
            }
        }

        internal int ExecuteSQLGetID(SqlCommand cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                cmd.Connection.Open();
                var v = cmd.ExecuteScalar();
                return (int)v; //Returns OUTPUT id
            }
        }

        //Retrieves data from SQL as a datatable
        internal DataTable SQL2Datatable(SqlCommand cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                adapter.Dispose();

                return dataTable;
            }
        }

        //Converts the datatable to list based on the item types
        internal List<T> Datatable2List<T>(DataTable dt)
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
