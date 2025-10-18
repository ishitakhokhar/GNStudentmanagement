using GNStudentManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BCrypt.Net;

namespace GNStudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly GnstudentManagementContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(GnstudentManagementContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

#region Register
        [HttpPost("register")]
        public IActionResult Register([FromBody] Register request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Password) || string.IsNullOrWhiteSpace(request.Email))
                return BadRequest(new { Message = "All fields are required." });

          
            if (_context.AcdStudents.Any(s => s.Email == request.Email))
                return BadRequest(new { Message = "Email already exists." });

            var student = new AcdStudent
            {
                StudentName = request.Name,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Phone = request.Phone,
                Created = DateTime.Now
            };

            _context.AcdStudents.Add(student);
            _context.SaveChanges();

            return Ok(new { Message = "Registration successful." });
        }

        #endregion

        #region login

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { Message = "Name and password are required." });

         
            var staff = _context.AcdStaffs.FirstOrDefault(s => s.StaffName == request.Name);
            if (staff != null)
            {
               
                if (!BCrypt.Net.BCrypt.Verify(request.Password, staff.Password))
                    return Unauthorized(new { Message = "Invalid password." });

             
                string role = staff.StaffName == "Admin" ? "Admin" : "Faculty";


                var token = GenerateJWTToken(staff.StaffId.ToString(), staff.StaffName, role);

                return Ok(new { Name = staff.StaffName, Role = role, Token = token });
            }

            var student = _context.AcdStudents.FirstOrDefault(s => s.StudentName == request.Name);
            if (student != null)
            {
                var token = GenerateJWTToken(student.StudentId.ToString(), student.StudentName, "Student");

                return Ok(new { Name = student.StudentName, Role = "Student", Token = token });
            }

            return NotFound(new { Message = "User not found." });
        }
        #endregion


        #region TokenGeneration
        private string GenerateJWTToken(string id, string name, string role)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", id),
                    new Claim(ClaimTypes.Name, name),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion


        #region PasswordHashGeneration
        [HttpPost("generate-password-hash")]
        public IActionResult GeneratePasswordHash([FromBody] string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                return BadRequest(new { Message = "Password is required." });

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(plainPassword);
            return Ok(new { Plain = plainPassword, Hashed = hashedPassword });
        }
        #endregion

    }
}


