using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<TaskContext>
    {
        protected override void Seed(TaskContext context)
        {
            context.Users.AddOrUpdate(
                 x => x.Id,
                 new User() { Id = 1, Name = "Vladyslav Saienko" },
                 new User() { Id = 2, Name = "Igor Polurezov" },
                 new User() { Id = 3, Name = "Dmytro Bilash" },
                 new User() { Id = 4, Name = "Vlad Klochkov" },
                 new User() { Id = 5, Name = "Vlad Voloshyn" }


                 );
            context.Tasks.AddOrUpdate(
              x => x.Id,
              new Task() { Id = 1, Name = "Todo1", Status = "Created", UserId = 1, Executor = "Unknown", Description="Todo todo todo" },
              new Task() { Id = 2, Name = "Todo2", Status = "Created", UserId = 2, Executor = "Saienko" , Description = "Todo todo todo" },
              new Task() { Id = 3, Name = "Todo3", Status = "Created", UserId = 3, Executor = "Unknown" ,Description = "Todo t" },
              new Task() { Id = 4, Name = "Todo4", Status = "Created", UserId = 5, Executor = "", Description="ff" }

              );
            context.Comments.AddOrUpdate(
              x => x.Id,
              new Comment() { Id = 1, CommentText = "Good", TaskId = 1 },
              new Comment() { Id = 2, CommentText = "Bad", TaskId = 2 },
              new Comment() { Id = 3, CommentText = "Nice", TaskId = 2 },
              new Comment() { Id = 4, CommentText = "Todo1", TaskId = 4 }

              );
        }
    }
}