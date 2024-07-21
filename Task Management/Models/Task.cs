using System.Reflection.Metadata;

namespace Task_Management.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DueDate { get; set; }
        public int AssignedToId { get; set; }
        public User AssignedTo { get; set; }
        public List<Document> Documents { get; set; }
        public List<Note> Notes { get; set; }
    }
}
