using System;
using TaskManagerPrototype2.Models.Entites;

namespace TaskManagerPrototype2.FormEntities
{
    public class TaskNoteForm
    {
        public string Title { get; set; }
        public string TextBody { get; set; }
        public int ProjectRefId { get; set; }
    }
}