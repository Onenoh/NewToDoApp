using System;
using System.Collections.Generic;
using System.Text;

namespace NewToDoApp
{
    internal class Task
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
        public Priority.PriorityLevel Priority { get; set; }
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; }
        public int Id  {get; set; } = UI.TaskCounter.GetNextID(); 
    }
}
