using BestilVasketidCoreAPI.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;


namespace BestilVasketidCoreAPI.Controllers
{
    public class UserCRUD
    {
        DBTools dbTools = new BestilVasketidCoreAPI.DBTools();

        internal int CreateUser(User user)
        {
            user.Timestamp = dbTools.CreateTimeStamp(); // Creates a new timestamp

            SqlCommand cmd = new SqlCommand("INSERT INTO [user] (email, phone, name, password, lastlogin, timestamp_fk)" +
    "OUTPUT INSERTED.id VALUES (@email, @phone, @name, @password, @lastlogin, @timestamp)");
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            cmd.Parameters["@email"].Value = user.Email;
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@lastlogin", user.LastLogin);
            cmd.Parameters.AddWithValue("@timestamp", user.Timestamp);

            return dbTools.ExecuteSQLGetID(cmd); //executes sqlcommand and returns id of created user
        }

        internal List<User> UserList()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [user]");
            DataTable dataTable = dbTools.SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return dbTools.Datatable2List<User>(dataTable);
            else return null;
        }

        internal User GetUserById(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [user] WHERE id = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = id;

            DataTable dataTable = dbTools.SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return dbTools.Datatable2List<User>(dataTable)[0];
            else return null;
        }
    

        internal void UpdateUser(int id, User user)
        {
            SqlCommand cmd = new SqlCommand("UPDATE [user] SET email = @email, phone = @phone, name = @name, " +
     "password = @password, lastlogin = @lastlogin OUTPUT inserted.timestamp_fk WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            cmd.Parameters["@email"].Value = user.Email;
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@lastlogin", user.LastLogin);
            //cmd.Parameters.AddWithValue("@timestamp", user.Timestamp);

            int timestamp = dbTools.ExecuteSQLGetID(cmd); //executes sqlcommand and returns timestamp of user
            dbTools.ChangeTimeStamp(timestamp); //Updates timestamp with [change] value
        }

        internal int DeleteUser(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE [user] OUTPUT DELETED.timestamp_fk WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            int timestamp = dbTools.ExecuteSQLGetID(cmd);
            return dbTools.DeleteTimeStamp(timestamp); //Updates timestamp with [deleted] value
        }

    }
}
