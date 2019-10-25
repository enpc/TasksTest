using System.Collections.Generic;

namespace Tasks.Models
{
    public interface ITasksRepository
    {
        Task AddTask(Task task);
        void DeleteTask(int id);
        Task RetriveTask(int id);
        Task[] RetriveTasks();
        Task UpdateTask(Task task);
    }
}