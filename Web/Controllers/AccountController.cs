using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Web.Entities;
using Web.Models;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AppDbContext _db;
        IConfiguration _config;
        public AccountController(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (employee != null)
            {
                if (ModelState.IsValid)
                {
                    //employee.PassWord = Encryption(employee.PassWord);
                    _db.Employees.Add(employee);
                    _db.SaveChanges();

                    return Created("Create",employee);
                }
            }

            return BadRequest("Please enter Proper input");
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (loginModel != null)
            {
                if (ModelState.IsValid)
                {
                    var EmailPassword = _db.Employees.Where(s => s.PassWord.Equals(loginModel.Password) &&
                                                    s.Email.Equals(loginModel.Email))?.FirstOrDefault();
                    if (EmailPassword != null)
                    {
                        UsersModel model = new UsersModel()
                        {
                            Id = EmailPassword.Id,
                            Name = EmailPassword.Name,
                            Gender = EmailPassword.Gender,
                            Mobile = EmailPassword.Mobile,
                            Email = EmailPassword.Email,
                            PassWord = EmailPassword.PassWord,
                            StateId = EmailPassword.StateId,
                            CitiesId = EmailPassword.CitiesId,
                            Image = EmailPassword.Image
                            //Tocken = "Tocken Value"
                        };
                        model.Tocken = GenerateTocken(model);

                        return Ok(model);
                    }
                    return NotFound("Users not exists....");
                }
                
            }

            return BadRequest("Please enter username and password");
        }
        [HttpGet]
        public static string Encryption(string password)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(password);
            string encript = Convert.ToBase64String(bytes);

            return encript;
        }
        [HttpGet]
        public static string Decription(string password)
        {
            byte[] bytes = Convert.FromBase64String(password);
            string Emcry = ASCIIEncoding.ASCII.GetString(bytes);

            return Emcry;
        }

        [HttpGet]
        private string GenerateTocken(UsersModel userModel)
        {
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userModel.Id.ToString()),
                        new Claim("DisplayName", userModel.Name),
                        new Claim("UserGender", userModel.Gender),
                        new Claim("Mobile", userModel.Mobile),
                        new Claim("Email",userModel.Email),
                        new Claim("Password", userModel.PassWord),
                        new Claim("StateId", (userModel.StateId).ToString()),
                        new Claim("CitiesId", (userModel.CitiesId).ToString()),
                        new Claim("ImagesId", (userModel.ImageId).ToString())
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
