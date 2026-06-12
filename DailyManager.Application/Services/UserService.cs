using Mapster;
using DailyManager.Application.DTOs;
using DailyManager.Application.Interfaces;
using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;

namespace DailyManager.Application.Services;
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
            return ResultDto<RegisterDto>.Failure(string.Format("Usuario já cadastrado"));

        var newUser = userRegisterDto.Adapt<User>();

        newUser.Id = Guid.NewGuid();
        newUser.CreatedAt = DateTime.UtcNow;
        newUser.HashPassword = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password);

        await _userRepository.AddAsync(newUser);
        return ResultDto<RegisterDto>.Success(string.Format("Usuario cadastrado com Sucesso"));
    }

    public async Task<ResultDto<LoginResponseDto>> LoginAsync(LoginRequestDto userLoginDto)
    {
        User? user = await _userRepository.GetByEmailAsync(userLoginDto.Email);

        if (user == null)
            return ResultDto<LoginResponseDto>.Failure("Usuario não encontrado");

        bool validPassword = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.HashPassword);

        if (!validPassword)
            return ResultDto<LoginResponseDto>.Failure("Usuário ou senha inválidos");

        string userToken = _jwtService.GenerateToken(user);

        var loginResponse = new LoginResponseDto
        {
            Token = userToken
        };

        return ResultDto<LoginResponseDto>.Success(loginResponse);
    }
}
