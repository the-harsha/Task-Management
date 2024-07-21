using Task_Management.Models;


namespace Task_Management.Interfaces
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskManagementContext _context;

        public TaskRepository(TaskManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Task>> GetAllAsync()
        {
            return await _context.Tasks.Include(t => t.AssignedTo).ToListAsync();
        }

        public async Task<Task> GetByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.Documents).Include(t => t.Notes).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Task task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Task task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Task>> GetTasksByUserIdAsync(int userId)
        {
            return await _context.Tasks.Where(t => t.AssignedToId == userId).ToListAsync();
        }

        public async Task<List<Task>> GetTasksByTeamIdAsync(int teamId)
        {
            return await _context.Tasks.Where(t => t.AssignedTo.TeamId == teamId).ToListAsync();
        }

        public async Task<List<Task>> GetTasksDueInTimeFrameAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Tasks.Where(t => t.DueDate >= startDate && t.DueDate <= endDate).ToListAsync();
        }
    }
}
