namespace project_manager.Domain.Entities
{
    public class WorkTaskUpdateHistory
    {
        public int WorkTaskUpdateHistoryId { get; set; }
        public int WorkTaskId { get; set; } 
        public WorkTask WorkTask { get; set; } 
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ModificationDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}