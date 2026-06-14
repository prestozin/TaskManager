namespace DailyManager.Core.Entities
{
    public class UserTask
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
