using TaskManager.Application.DTOs;
using TaskManager.Core.Entities;
using Mapster;
namespace TaskManager.Application.Mappings;

public class UserMapping 
{
    public void RegisterMapping(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterUserDto, User>()
            .Ignore(dest => dest.Id)
            .Ignore(dest => dest.HashPassword)
            .Ignore(dest => dest.CreatedAt);
    }
}
