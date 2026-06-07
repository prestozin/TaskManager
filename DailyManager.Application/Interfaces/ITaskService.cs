
using DailyManager.Application.DTOs;
using DailyManager.Core.Entities;

namespace DailyManager.Application.Interfaces;

public interface ITaskService
{
    Task<ResultDto<UserTask>> GetByTitle(string title);
}
