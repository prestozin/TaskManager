using DailyManager.Application.DTOs;

namespace DailyManager.Application.Interfaces;

public interface IUserService
{
    Task<ResultDto<RegisterDto>> RegisterAsync(RegisterDto userRegisterDto);
    Task<ResultDto<LoginDto>> LoginAsync(LoginDto userLoginDto);
}
