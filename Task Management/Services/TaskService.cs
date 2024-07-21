using Task_Management.Interfaces;

namespace Task_Management.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<Task>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllAsync();
        }

        public async Task<Task> GetTaskByIdAsync(int id)
        {
            return await _taskRepository.GetByIdAsync(id);
        }

        public async Task AddTaskAsync(Task task)
        {
            await _taskRepository.AddAsync(task);
        }

        public async Task UpdateTaskAsync(Task task)
        {
            await _taskRepository.UpdateAsync(task);
        }

        public async Task DeleteTaskAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
        }

        public async Task<List<Task>> GetTasksByUserIdAsync(int userId)
        {
            return await _taskRepository.GetTasksByUserIdAsync(userId);
        }

        public async Task<List<Task>> GetTasksByTeamIdAsync(int teamId)
        {
            return await _taskRepository.GetTasksByTeamIdAsync(teamId);
        }

        public async Task<List<Task>> GetTasksDueInWeekAsync()
        {
            var startDate = DateTime.Now;
            var endDate = startDate.AddDays(7);
            return await _taskRepository.GetTasksDueInTimeFrameAsync(startDate, endDate);
        }

        public async Task<List<Task>> GetTasksDueInMonthAsync()
        {
            var startDate = DateTime.Now;
            var endDate = startDate.AddMonths(1);
            return await _taskRepository.GetTasksDueInTimeFrameAsync(startDate, endDate);
        }
    }
}
