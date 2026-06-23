using TaskManager.Core.Enums;

namespace TaskManager.Core.Entities
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Guid? UserId { get; set; }
        public User? User { get; set; }
        public int StatusId { get; set; } = (int)StatusTaskEnum.Pending;
        public StatusTask? Status { get; set; }
    }
}
