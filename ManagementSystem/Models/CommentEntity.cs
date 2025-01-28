using ManagementSystem.DataTypes.Enums;

namespace ManagementSystem.Models
{
    public class CommentEntity
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public TaskEntity Task { get; set; }
        public DateTime DateAdded { get; set; }
        public string Comment { get; set; } = string.Empty;
        public CommentType CommentType { get; set; }
        public DateTime? ReminderDate { get; set; }
    }
}
