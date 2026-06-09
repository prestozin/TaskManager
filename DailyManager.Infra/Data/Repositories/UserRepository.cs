using DailyManager.Core.Entities;
using DailyManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace DailyManager.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<bool> ExistsAsync (string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
