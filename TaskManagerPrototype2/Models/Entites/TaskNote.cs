using System;

namespace TaskManagerPrototype2.Models.Entites
{
    public class TaskNote
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextBody { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime TargetDateTime { get; set; }
        public Project ProjectRef { get; set; }
        public User Author { get; set; }
    }
}