using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface IUserService
{
    Task<ResultDto<RegisterDto>> RegisterAsync(RegisterDto userRegisterDto);
    Task<ResultDto<LoginResponseDto>> LoginAsync(LoginRequestDto userLoginDto);
}
