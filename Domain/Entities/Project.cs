namespace project_manager.Domain.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; } 
        public User User { get; set; } 
        public ICollection<WorkTask> WorkTasks { get; set; }
    }
}
