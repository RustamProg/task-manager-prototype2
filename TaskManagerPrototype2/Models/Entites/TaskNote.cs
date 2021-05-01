using System;

namespace TaskManagerPrototype2.Models.Entites
{
    public class TaskNote : BaseEntity
    {
        public string Title { get; set; }
        public string TextBody { get; set; }
        public DateTime CreateDateTime { get; set; } = DateTime.Now;
        public DateTime TargetDateTime { get; set; } = DateTime.Now;
        public Project ProjectRef { get; set; }
        public User Author { get; set; }
    }
}