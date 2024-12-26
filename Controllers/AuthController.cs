using JwtImplementation.Interfaces;
using JwtImplementation.Models;
using JwtImplementation.RequestModels;
using JwtImplementation.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtImplementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        // POST api/<AuthController>
        [HttpPost]
        public string Login([FromBody] LoginRequest loginModel)
        {
            var res = _authService.Login(loginModel);

            return res;
        }

        [HttpPost("addUser")]
        public User AddUser([FromBody] User user)
        {
            var ur = _authService.AddUser(user);
            return ur;
        }

    }
}
