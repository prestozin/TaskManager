using Mapster;
using DailyManager.Application.DTOs;
using DailyManager.Application.Interfaces;
using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;

namespace DailyManager.Application.Services;
public class UserService : IUserService
{   
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

    public async Task<ResultDto<LoginDto>> LoginAsync(LoginDto userLoginDto)
    {
        User user = await _userRepository.GetByEmailAsync(userLoginDto.Email);

        if (user == null)
            return ResultDto<LoginDto>.Failure(string.Format("Usuario não encontrado"));

        bool validPassword = BCrypt.Net.BCrypt.Verify(userLoginDto.Password, user.HashPassword);

        if (!validPassword)
            return ResultDto<LoginDto>.Failure("Usuário ou senha inválidos");

        return ResultDto<LoginDto>.Success("Usuário logado com sucesso");
    }
}
