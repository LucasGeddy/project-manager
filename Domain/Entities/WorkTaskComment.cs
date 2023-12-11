namespace project_manager.Domain.Entities
{
    public class WorkTaskComment
    {
        public int WorkTaskCommentId { get; set; }
        public int WorkTaskId { get; set; } // Foreign key
        public WorkTask WorkTask { get; set; } // Navigation property
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public int UserId { get; set; } // Foreign key
        public User User { get; set; } // Navigation property
    }
}
