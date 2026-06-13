using DailyManager.Application.DTOs;
using DailyManager.Application.DTOs.Task;
using DailyManager.Core.Entities;
using Mapster;
namespace DailyManager.Application.Mappings;

public class TaskMapping 
{
    public void RegisterMapping(TypeAdapterConfig config)
    {
        config.NewConfig<TaskRequestDto, UserTask>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.CreatedAt, src => DateTime.UtcNow)
            .Ignore(dest => dest.UserId)
            .Ignore(dest => dest.IsCompleted);
    }
}
