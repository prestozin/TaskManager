using Mapster;
using TaskManager.Application.DTOs;
using TaskManager.Application.Interfaces;
using TaskManager.Core.Constants;
using TaskManager.Core.Entities;
using TaskManager.Core.Interfaces;

namespace TaskManager.Application.Services;
public class UserService : IUserService
{   
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    public UserService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }
    public async Task<ResultDto<RegisterDto>> RegisterAsync(RegisterDto userRegisterDto)
    {
        bool exists = await _userRepository.ExistsAsync(userRegisterDto.Email);

        if (exists)
            return ResultDto<RegisterDto>.Failure(string.Format(Messages.UserAlreadyExists));

        var newUser = userRegisterDto.Adapt<User>();

        newUser.Id = Guid.NewGuid();
        newUser.CreatedAt = DateTime.UtcNow;
        newUser.HashPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

        await _userRepository.AddAsync(newUser);
        return ResultDto<RegisterDto>.Success(string.Format(Messages.UserCreatedSucessfully));
    }

    public async Task<ResultDto<LoginResponseDto>> LoginAsync(LoginRequestDto userLoginDto)
    {
        User? user = await _userRepository.GetByEmailAsync(userLoginDto.Email);

        if (user == null)
            return ResultDto<LoginResponseDto>.Failure(Messages.UserNotFound);

        bool validPassword = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.HashPassword);

        if (!validPassword)
            return ResultDto<LoginResponseDto>.Failure(Messages.UserOrPasswordInvalid);

        string userToken = _jwtService.GenerateToken(user);

        var loginResponse = new LoginResponseDto
        {
            Token = userToken
        };

        return ResultDto<LoginResponseDto>.Success(loginResponse);
    }
}
