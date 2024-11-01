using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Filmlist.Classes;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Filmlist.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginDto)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password);

            if (user == null)
            {
                return Unauthorized(); 
            }

            var token = GenerateJwtToken(user);

            // Include the user ID in the response
            return Ok(new { token, userId = user.Id }); // Assuming user.Id is the ID of the user
        }


        private string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("isafknjjdjfjdsaofaoifaiJEUHWUOIJ9384U29848HDAJNJkdaj9dan35n32n5")); //Muss nach der Entwicklung sicherer gemacht werden
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "localhost", 
                audience: "localhost", 
                claims: claims,
                expires: DateTime.Now.AddMinutes(30), 
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // POST api/user
        [HttpPost("register")]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            if (newUser == null)
            {
                return BadRequest();
            }
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }



        // Example data store
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "Alice" },
            new User { Id = 2, Username = "Bob" }
        };

        // GET api/user
        [Authorize]
        [HttpGet]
       public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
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
