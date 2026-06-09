
using DailyManager.Core.Entities;

namespace DailyManager.Core.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<bool> ExistsAsync(string email);

}
