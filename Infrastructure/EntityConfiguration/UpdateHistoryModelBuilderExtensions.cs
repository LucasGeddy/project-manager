using Microsoft.EntityFrameworkCore;
using project_manager.Domain.Entities;

namespace project_manager.Infrastructure.Entities
{
    public static class UpdateHistoryModelBuilderExtensions
    {
        public static ModelBuilder ConfigureUpdateHistory(this ModelBuilder modelBuilder)
        {
            var workTaskUpdateHistoryBuilder = modelBuilder.Entity<WorkTaskUpdateHistory>();
            workTaskUpdateHistoryBuilder.HasKey(h => h.WorkTaskUpdateHistoryId);
            workTaskUpdateHistoryBuilder.HasOne(h => h.WorkTask)
                .WithMany(t => t.UpdateHistory)
                .HasForeignKey(h => h.WorkTaskId)
                .OnDelete(DeleteBehavior.Cascade);
            workTaskUpdateHistoryBuilder.HasOne(h => h.User)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            workTaskUpdateHistoryBuilder.Property(h => h.PropertyName)
                .IsRequired();
            workTaskUpdateHistoryBuilder.Property(h => h.OldValue)
                .IsRequired();
            workTaskUpdateHistoryBuilder.Property(h => h.NewValue)
                .IsRequired();
            workTaskUpdateHistoryBuilder.Property(h => h.ModificationDate)
                .IsRequired();
            return modelBuilder;
        }
    }
}
