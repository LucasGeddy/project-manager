namespace project_manager.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
