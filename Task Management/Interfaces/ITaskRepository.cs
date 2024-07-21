namespace Task_Management.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<Task>> GetAllAsync();
        Task<Task> GetByIdAsync(int id);
        Task AddAsync(Task task);
        Task UpdateAsync(Task task);
        Task DeleteAsync(int id);
        Task<List<Task>> GetTasksByUserIdAsync(int userId);
        Task<List<Task>> GetTasksByTeamIdAsync(int teamId);
        Task<List<Task>> GetTasksDueInTimeFrameAsync(DateTime startDate, DateTime endDate);
    }
}