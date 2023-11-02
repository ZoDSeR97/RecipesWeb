using Microsoft.AspNetCore.Mvc;
using RecipesWeb.Shared;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using RecipesWeb.Server.Models;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecipesWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        MyContext _context;
        private readonly IConfiguration _configuration;
        //private readonly IUserService _userService;

        public UserController(MyContext context, IConfiguration configuration /*, IUserService userService*/)
        {
            _context = context;
            _configuration = configuration;
            //_userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}"), Authorize(Roles = "Admin")]
        public string Get(int id)
        {
            User? user = _context.Users.FirstOrDefault(record=>record.Id==id);
            if (user != null) {
                string Token = CreateToken(user);
                return Token;
            }
            return "Mama just kill a man";
        }

        // POST api/<UserController>
        [HttpPost, Authorize(Roles = "User")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}"), Authorize(Roles = "User")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}"), Authorize(Roles = "User")]
        public void Delete(int id)
        {
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
