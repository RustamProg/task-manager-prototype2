using System;

namespace TaskManagerPrototype2.Models.Entites
{
    public class TaskComment
    {
        public int Id { get; set; }
        public string TextBody { get; set; }
        public User Author { get; set; }
        public TaskNote TaskNote { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}