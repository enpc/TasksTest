using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tasks.Services;

namespace Tasks.Models
{
    public class TasksModel : ITasksModel
    {
        private readonly ITasksRepository Repository;
        private readonly ITimeService TimeService;

        public TasksModel(ITasksRepository repository, ITimeService timeService)
        {
            Repository = repository ?? throw new ArgumentException("Repository cannot be null");
            TimeService = timeService ?? throw new ArgumentException("TimeService cannot be null");
        }

        public TaskModel CreateTask(string name, string description)
        {
            var newTask = Repository.AddTask(new Task { Name = name, Description = description, State = TaskStates.Todo });
            return TaskModelFromTask(newTask);
        }

        public TaskModel GetTask(int id)
        {
            var task = Repository.RetriveTask(id);
            if (task == null)
            {
                throw new ArgumentOutOfRangeException($"The task with id {id} does not exists");
            }
            return TaskModelFromTask(task);
        }

        public TaskModel[] GetTasks()
        {
            return Repository.RetriveTasks().Select(s => TaskModelFromTask(s)).ToArray();
        }

        public TaskModel UpdateTask(TaskModel task)
        {
            var updatedTask = Repository.UpdateTask(TaskFromTaskModel(task));
            return TaskModelFromTask(updatedTask);

        }

        public void DeleteTask(TaskModel task)
        {
            Repository.DeleteTask(task.Id);
        }

        private TaskModel TaskModelFromTask(Task task)
        {
            return new TaskModel(TimeService, task.Id, task.State, task.Started, task.Ended)
            {
                Name = task.Name,
                Description = task.Description
            };
        }

        private Task TaskFromTaskModel(TaskModel task)
        {
            return new Task()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                State = task.State,
                Started = task.Started,
                Ended = task.Ended
            };
        }

        public static ITasksModel GetInstance()
        {
            return new TasksModel(new TasksRepository(), new TimeService());
        }
    }
}