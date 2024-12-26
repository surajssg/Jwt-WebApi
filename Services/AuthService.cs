using JwtImplementation.Context;
using JwtImplementation.Interfaces;
using JwtImplementation.Models;
using JwtImplementation.RequestModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtImplementation.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _jwtContext;
        private readonly IConfiguration _configuration;

        public AuthService(JwtContext jwtContext, IConfiguration configuration)
        {
            _jwtContext = jwtContext;
            _configuration = configuration;
        }

        public User AddUser(User user)
        {
            var addedUser = _jwtContext.Users.Add(user);
            _jwtContext.SaveChanges();
            return addedUser.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                throw new Exception("Credentials are not valid!!");

            var user = _jwtContext.Users.FirstOrDefault(s => s.email == loginRequest.UserName && s.password == loginRequest.Password);
            if (user == null)
                throw new Exception("User is not valid!!");

            var claims = new[]
            {
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim("Id", user.id.ToString()),
                new Claim("UserName", user.name),
                new Claim("Email", user.email),
                new Claim(ClaimTypes.Role , user.role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
