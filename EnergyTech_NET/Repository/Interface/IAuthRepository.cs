using EnergyTech_NET.DTOs;

namespace EnergyTech_NET.Repository.Interface
{
    public interface IAuthRepository
    {
        Task<string> RegisterUserAsync(RegisterDTO registerDto); 
        Task<string> LoginUserAsync(LoginDTO loginDto); 
    }
}
