using TaskManager.Application.DTOs;

namespace TaskManager.Application.Interfaces;

public interface IUserService
{
    Task<ResultDto<CreateUserDto>> RegisterAsync(CreateUserDto userRegisterDto);
    Task<ResultDto<LoginResponseDto>> LoginAsync(UserLoginDto userLoginDto);
}
