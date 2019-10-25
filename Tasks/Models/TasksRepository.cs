using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tasks.Models
{
    public class TasksRepository : ITasksRepository
    {
        public Task AddTask(Task task)
        {
            using (var db = new TasksContext())
            {
                var result = db.Tasks.Add(task);
                db.SaveChanges();
                return result;
            }
        }

        public Task RetriveTask(int id)
        {
            using (var db = new TasksContext())
            {
                return db.Tasks.FirstOrDefault(s => s.Id == id);
            }
        }

        public Task[] RetriveTasks()
        {
            using (var db = new TasksContext())
            {
                return db.Tasks.ToArray();
            }
        }

        public Task UpdateTask(Task task)
        {
            using (var db = new TasksContext())
            {
                db.Entry(task).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return task;
            }
        }

        public void DeleteTask(int id)
        {
            using (var db = new TasksContext())
            {
                db.Entry(db.Tasks.FirstOrDefault(s => s.Id == id)).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}