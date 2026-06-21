
using TaskManager.Core.Entities;

namespace TaskManager.Core.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<bool> ExistsAsync(string email);
    Task<User?> GetByEmailAsync(string email);
}
