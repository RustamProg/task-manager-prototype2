using System;

namespace TaskManagerPrototype2.Application.Models.ModelEntities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TextBody { get; set; }
        public User Author { get; set; }
        public DateTime Create_date { get; set; }
    }
}