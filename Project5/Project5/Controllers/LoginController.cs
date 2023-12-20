using Microsoft.AspNetCore.Authorization;
using Project5.Data;
using Microsoft.AspNetCore.Mvc;
using Project5.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContex _dbContext;
        public LoginController(IConfiguration configuration, DataContex dataContex)
        {
            _configuration = configuration;
            _dbContext = dataContex;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            try
            {
                var user = Authenticate(userName, password);

                if (user != null)
                {
                    var token = Generate(user);
                    return Ok(token);
                }

                return NotFound("User not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private User Authenticate(string userName, string password)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password && x.IsActive);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string Generate(User user)
        {
            try
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var role = _dbContext.UserRolls.FirstOrDefault(x => x.RollId == user.RollId);
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role.RollType),
                    new Claim(ClaimTypes.MobilePhone, user.Phone)
                };

                var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                  _configuration["Jwt:Audience"],
                  claims,
                  expires: DateTime.Now.AddHours(3),
                  signingCredentials: credentials);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
