using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using PMT.API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PMT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User Userdetails)
        {
            if ((Userdetails.username == "manager" && Userdetails.PassWord == "manager") || (Userdetails.username == "member" && Userdetails.PassWord  == "member"))
            {

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes("c87ebd3f-c4d8-4f15-81db-4f94363a2038");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, "admin@gmail.com")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenkey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { status = "Ok",role= Userdetails.username, token = tokenHandler.WriteToken(token) });
            }
            else
                return Unauthorized();
        

    }
        [HttpGet("login1")]
        public IActionResult Login()
        {


                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenkey = Encoding.UTF8.GetBytes("c87ebd3f-c4d8-4f15-81db-4f94363a2038");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Email, "admin@gmail.com")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(tokenkey),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(new { status = "Ok", role ="MemberAccessException", token = tokenHandler.WriteToken(token) });
          


        }
    }
}
