using Microsoft.EntityFrameworkCore;
using project_manager.Domain.Entities;

namespace project_manager.Infrastructure.Entities
{
    public static class CommentsModelBuilderExtensions
    {
        public static ModelBuilder ConfigureComments(this ModelBuilder modelBuilder)
        {
            var workTaskCommentsBuilder = modelBuilder.Entity<WorkTaskComment>();
            workTaskCommentsBuilder.HasKey(c => c.WorkTaskCommentId);
            workTaskCommentsBuilder.HasOne(c => c.WorkTask)
                .WithMany(t => t.Comments)
                .HasForeignKey(c => c.WorkTaskId)
                .OnDelete(DeleteBehavior.Cascade);
            workTaskCommentsBuilder.HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            workTaskCommentsBuilder.Property(c => c.Comment)
                .IsRequired()
                .HasMaxLength(500);
            workTaskCommentsBuilder.Property(c => c.CommentDate)
                .IsRequired();
            return modelBuilder;
        }
    }
}
