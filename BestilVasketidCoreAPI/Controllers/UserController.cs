using System.Collections.Generic;
using BestilVasketidCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestilVasketidCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DBTools dbTools = new DBTools();
        UserCRUD uc = new UserCRUD();

        // GET: api/User
        [HttpGet]
        public List<DTO_User> Get()
        {
            List<User> userlist = uc.UserList();
            if (userlist == null) return null;

            List<DTO_User> users = new List<DTO_User>();
            foreach (var u in userlist)
            {
                TimeStamp t = null;
                if (u.Timestamp == null) u.Timestamp = dbTools.CreateTimeStamp(); 
                t = dbTools.GetTimeStamp(u.Timestamp);
              
                users.Add(new DTO_User() { user = u, timestamp = t });
            }
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "GetById")]
        public DTO_User GetUser(int id)
        {
            User u = uc.GetUserById(id);
            TimeStamp t = dbTools.GetTimeStamp(u.Timestamp);
            DTO_User user = new DTO_User() { user = u, timestamp = t};

            return user;
        }

        // POST: api/User (Returns ID of user created)
        [HttpPost]
        public int Post([FromBody] DTO_User dto_user)
        {
            return uc.CreateUser(dto_user.user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DTO_User dto_user)
        {
            uc.UpdateUser(id, dto_user.user);

        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            uc.DeleteUser(id);
        }
    }
}
