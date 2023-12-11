using FluentValidation;
using Microsoft.EntityFrameworkCore;
using project_manager.Application.Interfaces.Project;
using project_manager.Infrastructure;

namespace project_manager.Application.Services.Project
{
    public class GetProjectService : IGetProjectService
    {
        private readonly TaskManagerDbContext dbContext;
        public GetProjectService(TaskManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IResult> GetAllProjectsAsync(int userId)
        {
            var response =
                await dbContext.Projects
                .Where(p => p.UserId == userId)
                .Select(p => new ProjectGetResponse(p.ProjectId, p.Title, p.User.UserName))
                .ToListAsync();

            return Results.Ok(response);
        }
    }
}
