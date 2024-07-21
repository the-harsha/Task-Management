namespace Task_Management.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
