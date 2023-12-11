using Microsoft.EntityFrameworkCore;
using project_manager.Domain.Entities;

namespace project_manager.Infrastructure.Entities
{
    public static class UserModelBuilderExtensions
    {
        public static ModelBuilder ConfigureUser(this ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<User>();
            builder.HasKey(u => u.UserId);
            builder.HasMany(u => u.Projects)
                .WithOne(p => p.User);
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(50);
            return modelBuilder;
        }
    }
}
