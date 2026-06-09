using DailyManager.Application.DTOs;
using DailyManager.Core.Entities;
using Mapster;
namespace DailyManager.Application.Mappings;

public class UserMapping 
{
    public void RegisterMapping(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterDto, User>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.HashPassword)
            .Ignore(dest => dest.CreatedAt);
    }
}
