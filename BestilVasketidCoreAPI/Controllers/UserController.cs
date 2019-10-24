using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using BestilVasketidCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestilVasketidCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DBTools dbTools = new DBTools();

        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [user]");
            DataTable dataTable = dbTools.SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return dbTools.Datatable2List<User>(dataTable);
            else return null;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [user] WHERE id = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = id;

            DataTable dataTable = dbTools.SQL2Datatable(cmd);
            if (dataTable.Rows.Count > 0) return dbTools.Datatable2List<User>(dataTable)[0];
            else return null;
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            user.Timestamp = dbTools.CreateTimeStamp();

            SqlCommand cmd = new SqlCommand("INSERT INTO [user] (email, phone, name, password, lastlogin, timestamp_fk)" +
                "OUTPUT INSERTED.id VALUES (@email, @phone, @name, @password, @lastlogin, @timestamp)");
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            cmd.Parameters["@email"].Value = user.Email;
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@lastlogin", user.LastLogin);
            cmd.Parameters.AddWithValue("@timestamp", user.Timestamp); //

            int id = dbTools.ExecuteSQLGetID(cmd); //returns id of created user
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
             SqlCommand cmd = new SqlCommand("UPDATE [user] SET email = @email, phone = @phone, name = @name, " +
                 "password = @password, lastlogin = @lastlogin WHERE id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50);
            cmd.Parameters["@email"].Value = user.Email;
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@lastlogin", user.LastLogin);
            //cmd.Parameters.AddWithValue("@timestamp", user.Timestamp);

            dbTools.ExecuteSQL(cmd); //returns number of rows changed
            dbTools.ChangeTimeStamp(id);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand("DELETE [user] where id = @id");
            cmd.Parameters.AddWithValue("@id", id);
            dbTools.ExecuteSQL(cmd);
            dbTools.DeleteTimeStamp(id);
        }
    }
}
