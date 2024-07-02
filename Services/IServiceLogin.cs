using MultitrabajosSecurity.DTOs;

namespace MultitrabajosSecurity.Services
{
    public interface IServiceLogin
    {
        Task<Models.User> Login(LoginRequest loginRequest);

        object generarToken(Models.User user);
    }
}
