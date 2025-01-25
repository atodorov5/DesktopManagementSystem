namespace ManagementSystem.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<TaskEntity> Tasks { get; set; } = [];
    }
}
