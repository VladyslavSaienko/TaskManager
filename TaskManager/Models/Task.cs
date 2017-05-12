using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{

    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Executor { get; set; }
        public string Description { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Task()
        {
            Comments = new List<Comment>();
        }
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}