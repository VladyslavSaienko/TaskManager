using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class CommentsController : ApiController
    {
        TaskContext context = new TaskContext();

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments;
        }
        
        [HttpPost]
        public void CreateComment([FromBody]Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
