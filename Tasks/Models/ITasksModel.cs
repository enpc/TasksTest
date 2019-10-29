namespace Tasks.Models
{
    public interface ITasksModel
    {
        TaskModel CreateTask(string name, string description);
        void DeleteTask(TaskModel task);
        TaskModel GetTask(int id);
        TaskModel[] GetTasks();
        TaskModel UpdateTask(TaskModel task);
    }
}