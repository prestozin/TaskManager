using DailyManager.Application.DTOs;
using DailyManager.Application.Interfaces;

namespace DailyManager.Application.Services;
public class UserService : IUserService
{   
    public async Task<ResultDto<UserRegisterDto>> RegisterAsync(UserRegisterDto userRegisterDto)
    {

    }

    public async Task<ResultDto<UserLoginDto>> LoginAsync(UserLoginDto userLoginDto)
    {

    }
}
