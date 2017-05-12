using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Task> Tasks { get; set; }
        public User()
        {
            Tasks = new List<Task>();
        }
    }
}