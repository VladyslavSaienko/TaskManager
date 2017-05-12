using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TasksController : ApiController
    {
        public TaskContext db = new TaskContext();

        // GET: api/Tasks
        public IQueryable<TaskDTO> GetTasks()
        {
            var tasks = from t in db.Tasks
                        select new TaskDTO()
                        {
                            Id = t.Id,
                            Name = t.Name,
                            Author = t.User.Name
                        };

            return tasks;
        }

        // GET: api/Tasks/5
        [ResponseType(typeof(TaskDetailDTO))]
        public async Task<IHttpActionResult> GetTask(int id)
        {
            var task = await db.Tasks.Include(t => t.User).Select(t =>
                new TaskDetailDTO()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Executor = t.Executor,
                    Status = t.Status,
                    AuthorName = t.User.Name,
                    Description = t.Description
                }).SingleOrDefaultAsync(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Id)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(Models.Task))]
        public IHttpActionResult PostTask(Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tasks.Add(task);
            
            db.SaveChanges();

            db.Entry(task).Reference(x => x.User).Load();
            var dto = new TaskDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Author = task.User.Name
            };
            return CreatedAtRoute("DefaultApi", new { id = task.Id }, dto);
        }

        // DELETE: api/Tasks/5
        [ResponseType(typeof(Models.Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Models.Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.Id == id) > 0;
        }
    }
}