namespace project_manager.Domain.Entities
{
    public class WorkTask
    {
        public int WorkTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public WorkTaskStatus Status { get; set; }
        public WorkTaskPriority Priority { get; set; }
        public int ProjectId {  get; set; }
        public Project Project { get; set; }
        public ICollection<WorkTaskUpdateHistory> UpdateHistory { get; set; }
        public ICollection<WorkTaskComment> Comments { get; set; }
    }

    public enum WorkTaskPriority
    {
        Low,
        Medium,
        High
    }

    public enum WorkTaskStatus
    {
        Pending,
        InProgress,
        Done
    }
}
