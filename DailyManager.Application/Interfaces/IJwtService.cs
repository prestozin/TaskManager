using TaskManager.Core.Entities;

namespace TaskManager.Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(User user);
}
