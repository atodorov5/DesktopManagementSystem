﻿namespace ManagementSystem.Models
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<TaskEntity> Tasks { get; set; } = [];
    }
}
