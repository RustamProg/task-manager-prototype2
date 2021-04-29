using System;

namespace TaskManagerPrototype2.Models.Entites
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime TargetDateTime { get; set; }
        public User Manager { get; set; }
    }
}