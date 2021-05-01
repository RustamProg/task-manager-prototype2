using System;
using System.Text.Json.Serialization;

namespace TaskManagerPrototype2.Models.Entites
{
    public class Project: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime TargetDateTime { get; set; } = DateTime.Now;
        [JsonIgnore]
        public User Manager { get; set; }
        public int ManagerId { get; set; }
    }
}