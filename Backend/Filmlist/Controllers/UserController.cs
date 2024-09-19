using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Filmlist.Classes;

namespace Filmlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        // Example data store
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "Alice" },
            new User { Id = 2, Username = "Bob" }
        };

        // GET api/user
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(users);
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }
            newUser.Id = users.Max(u => u.Id) + 1;
            users.Add(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            users.Remove(user);
            return NoContent();
        }
    }
}
