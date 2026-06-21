using TaskManager.Application.DTOs;
using TaskManager.Application.DTOs.Task;
using TaskManager.Core.Entities;
using Mapster;
namespace TaskManager.Application.Mappings;

public class TaskMapping 
{
    public void RegisterMapping(TypeAdapterConfig config)
    {
        config.NewConfig<TaskRequestDto, TaskItem>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Map(dest => dest.CreatedAt, src => DateTime.UtcNow)
            .Ignore(dest => dest.UserId)
            .Ignore(dest => dest.IsCompleted);

        config.NewConfig<TaskItem, TaskResponseDto>()
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Title, src =>src.Title)
            .Map(dest => dest.Description, src => src.Description);
    }
}
