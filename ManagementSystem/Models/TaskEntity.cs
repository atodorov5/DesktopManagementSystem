using ManagementSystem.DataTypes.Enums;

namespace ManagementSystem.Models
{
    public class TaskEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public DataTypes.Enums.TaskStatus Status { get; set; }
        public TaskType Type { get; set; }
        public IEnumerable<UserEntity> Users { get; set; } = [];
        public DateTime? NextActionDate { get; set; }
        public IEnumerable<CommentEntity> Comments { get; set; }
    }
}
