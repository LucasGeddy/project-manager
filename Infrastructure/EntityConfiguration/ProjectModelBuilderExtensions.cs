using Microsoft.EntityFrameworkCore;
using project_manager.Domain.Entities;

namespace project_manager.Infrastructure.Entities
{
    public static class ProjectModelBuilderExtensions
    {
        public static ModelBuilder ConfigureProjects(this ModelBuilder modelBuilder)
        {
            var projectBuilder = modelBuilder.Entity<Project>();
            projectBuilder.HasKey(p => p.ProjectId);
            projectBuilder.HasMany(p => p.WorkTasks)
                .WithOne(wt => wt.Project);
            projectBuilder.HasOne(p => p.User)
                .WithMany(u => u.Projects)
                .HasForeignKey(p => p.UserId);
            projectBuilder.Property(p => p.Title)
                .IsRequired()
                .HasMaxLength(50);
            return modelBuilder;
        }
    }
}
