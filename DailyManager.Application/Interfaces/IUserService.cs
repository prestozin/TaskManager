using DailyManager.Application.DTOs;

namespace DailyManager.Application.Interfaces;

public interface IUserService
{
    Task<ResultDto<UserRegisterDto>> RegisterAsync(UserRegisterDto userRegisterDto);
    Task<ResultDto<UserLoginDto>> LoginAsync(UserLoginDto userLoginDto);
}
