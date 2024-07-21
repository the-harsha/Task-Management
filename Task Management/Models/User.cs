namespace Task_Management.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., Employee, Manager, Admin
        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
