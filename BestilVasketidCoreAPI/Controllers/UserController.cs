using System.Collections.Generic;
using System.Net.Http;
using BestilVasketidCoreAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestilVasketidCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UserController : ControllerBase
    {
        DBTools dbTools = new DBTools();
        UserCRUD uc = new UserCRUD();

        // GET: api/User
        [HttpGet]
        public List<User> Get()
        {
            return uc.UserList();
        }

        //// GET: api/User/5
        //[HttpGet("{id}", Name = "GetById")]
        //public User GetUser(int id)
        //{
        //    return uc.GetUserById(id);
        //}

        //// GET: api/User/email/xx@xx.xx
        //[HttpGet("email/{email}", Name = "GetUserByEmail")]
        //public User GetUserByEmail(string email)
        //{
        //    return uc.GetUserByEmail(email);      
        //}

        // GET: api/User/login + [Body]
        //[HttpPost("login/{id}", Name = "CanLogin")]
        //public HttpResponseMessage GetLogin([FromBody] LoginUser login)
        //{
        //    User user = uc.GetUserByEmail(login.Email);
        //    if (user == null || login.Password != user.Password) return BadRequest();
        //    else Request.CreateResponse(HttpStatusCode.Created, model); ;
        //}

        [EnableCors("CorsPolicy")]
        [HttpPost("login", Name = "CanLogin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> GetUser([FromBody] LoginUser login)
        {
            User user = uc.GetUserByEmail(login.Email);

            if (user == null || login.Password != user.Password) return BadRequest();
            return Ok(user);

            //return CreatedAtActionResult(user);
            //pet.Id = _petsInMemoryStore.Any() ? _petsInMemoryStore.Max(p => p.Id) + 1 : 1;
            //_petsInMemoryStore.Add(pet);

            //return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }



        //[HttpGet("emailexists/{email}", Name = "GetUserExistsByEmail")]
        //public bool GetUserExistsByEmail(string email)
        //{
        //    return uc.GetUserExistsByEmail(email);
        //}

        //// POST: api/User (Returns ID of user created)
        //[HttpPost]
        //public int Post([FromBody] User user)
        //{
        //    return uc.CreateUser(user);
        //}

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] User user)
        //{
        //    uc.UpdateUser(id, user);

        //}

        //// DELETE: api/User/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    uc.DeleteUser(id);
        //}
    }
}
