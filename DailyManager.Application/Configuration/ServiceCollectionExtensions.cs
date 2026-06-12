using DailyManager.Application.Interfaces;
using DailyManager.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DailyManager.Application.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}
