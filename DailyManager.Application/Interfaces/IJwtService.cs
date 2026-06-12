using DailyManager.Core.Entities;

namespace DailyManager.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
