using TaskManager.Application.DTOs;
using TaskManager.Core.Entities;
using Mapster;
namespace TaskManager.Application.Mappings;

public class TaskMapping : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateTaskDto, TaskItem>()
            .Map(dest => dest.Id, src => Guid.NewGuid())
            .Ignore(dest => dest.CreatedAt)
            .Ignore(dest => dest.UserId!);
  

        config.NewConfig<TaskItem, TaskResponseDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.Title, src =>src.Title)
            .Map(dest => dest.Description, src => src.Description)
            .Map(dest => dest.Status, src => src.Status!.Name);

        config.NewConfig<EditTaskDto, TaskItem>()
           .Ignore(dest => dest.CreatedAt)
           .Ignore(dest => dest.Id!)
           .Map(dest => dest.Title, src => src.Title)
           .Map(dest => dest.Description, src => src.Description)
           .Map(dest => dest.StatusId, src => src.StatusId);
    }
}
