using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }

        public int? TaskId { get; set; }
        public Task Task { get; set; }
    }
}