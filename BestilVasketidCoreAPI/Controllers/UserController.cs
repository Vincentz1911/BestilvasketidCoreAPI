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
        DBTools dbt = new DBTools();

        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [user]");           
            return dbt.Datatable2List<User>(dbt.SQL2Datatable(cmd));
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * from [user] WHERE id = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int);
            cmd.Parameters["@ID"].Value = id;

            return dbt.Datatable2List<User>(dbt.SQL2Datatable(cmd))[0];
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            user.Timestamp = dbt.CreateTimeStamp();

            SqlCommand cmd = new SqlCommand("INSERT INTO [user] VALUES" +
                "(@email, @phone, @name, @password, @lastlogin, @timestamp");
            cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = user.Email;
            //cmd.Parameters["@email"].Value = user.Email;
            cmd.Parameters.AddWithValue("@phone", user.Phone);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@password", user.Password);
            cmd.Parameters.AddWithValue("@lastlogin", user.LastLogin);
            cmd.Parameters.AddWithValue("@timestamp", user.Timestamp);

            dbt.ExecuteSQL(cmd);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
