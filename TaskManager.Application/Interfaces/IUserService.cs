using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface IUserService
{
    Task<ResultDto<RegisterUserDto>> RegisterAsync(RegisterUserDto userRegisterDto);
    Task<ResultDto<LoginResponseDto>> LoginAsync(UserLoginDto userLoginDto);
}
