using Microsoft.EntityFrameworkCore;
using project_manager.Domain.Entities;
using project_manager.Infrastructure.Entities;

namespace task_manager_challenge.Infrastructure
{
    public class TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<WorkTaskUpdateHistory> WorkTaskUpdateHistories { get; set; }
        public DbSet<WorkTaskComment> WorkTaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ConfigureUser()
                .ConfigureProjects()
                .ConfigureWorkTasks()
                .ConfigureComments()
                .ConfigureUpdateHistory();
        }
    }
}
