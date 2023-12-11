using Microsoft.EntityFrameworkCore;
using project_manager.Domain.Entities;

namespace project_manager.Infrastructure.Entities
{
    public static class WorkTaskModelBuilderExtensions
    {
        public static ModelBuilder ConfigureWorkTasks(this ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<WorkTask>();
            builder.HasKey(t => t.WorkTaskId);
            builder.HasOne(t => t.Project)
                .WithMany(p => p.WorkTasks)
                .HasForeignKey(t => t.ProjectId);
            builder.HasMany(t => t.Comments)
                .WithOne(c => c.WorkTask);
            builder.HasMany(t => t.UpdateHistory)
                .WithOne(h => h.WorkTask);
            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(t => t.Description)
                .HasMaxLength(200);
            builder.Property(t => t.Priority)
                .IsRequired()
                .HasMaxLength(30)
                .HasConversion<string>();
            builder.Property(t => t.Status)
                .IsRequired()
                .HasMaxLength(30)
                .HasConversion<string>();
            return modelBuilder;
        }
    }
}
