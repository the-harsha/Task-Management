﻿namespace Task_Management.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }
    }
}
