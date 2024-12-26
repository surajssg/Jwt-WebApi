using JwtImplementation.Models;
using JwtImplementation.RequestModels;

namespace JwtImplementation.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
