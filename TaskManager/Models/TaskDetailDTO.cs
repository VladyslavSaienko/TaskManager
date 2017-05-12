using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class TaskDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string Status { get; set; }
        public string Executor { get; set; }
        public string Description { get; set; }
    }
}