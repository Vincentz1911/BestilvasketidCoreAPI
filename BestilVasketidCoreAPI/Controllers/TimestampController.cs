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
    public class TimestampController : ControllerBase
    {
        DBTools dbt = new DBTools();

        // GET: api/TimeStamp
        [HttpGet]
        public List<TimeStamp> Get()
        {
            SqlCommand cmd = new SqlCommand("SELECT * from [timestamp]");           
            return dbt.Datatable2List<TimeStamp>(dbt.SQL2Datatable(cmd));
        }

        // GET: api/TimeStamp/5
        [HttpGet("{id}", Name = "Get")]
        public TimeStamp Get(int id)
        {
            SqlCommand cmd = new SqlCommand($"SELECT * from [timestamp] WHERE id = @id");
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            //cmd.Parameters["@ID"].Value = id;

            return dbt.Datatable2List<TimeStamp>(dbt.SQL2Datatable(cmd))[0];
        }

        // POST: api/TimeStamp
        [HttpPost]
        public int Post([FromBody] TimeStamp timestamp)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO [timestamp] OUTPUT INSERTED.id (created) VALUES (@created)");
            cmd.Parameters.Add("@created", SqlDbType.DateTime).Value = System.DateTime.Now;                    
            return dbt.ExecuteSQLGetID(cmd);
        }

        // PUT: api/TimeStamp/5
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
