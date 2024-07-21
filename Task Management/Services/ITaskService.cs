namespace Task_Management.Services
{
    public interface ITaskService
    {
        Task<List<Task>> GetAllTasksAsync();
        Task<Task> GetTaskByIdAsync(int id);
        Task AddTaskAsync(Task task);
        Task UpdateTaskAsync(Task task);
        Task DeleteTaskAsync(int id);
        Task<List<Task>> GetTasksByUserIdAsync(int userId);
        Task<List<Task>> GetTasksByTeamIdAsync(int teamId);
        Task<List<Task>> GetTasksDueInWeekAsync();
        Task<List<Task>> GetTasksDueInMonthAsync();
    }
}
