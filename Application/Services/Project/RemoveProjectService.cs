using FluentValidation;
using project_manager.Application.Interfaces.Project;
using project_manager.Domain.Entities;
using task_manager_challenge.Infrastructure;

namespace project_manager.Application.Services.Project
{
    public class RemoveProjectService : IRemoveProjectService
    {
        private readonly TaskManagerDbContext dbContext;
        private readonly IValidator<ProjectRemoveRequest> validator;
        public RemoveProjectService(TaskManagerDbContext dbContext, IValidator<ProjectRemoveRequest> validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;

        }
        public async Task<IResult> RemoveProjectAsync(ProjectRemoveRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.ToString());

            var project = dbContext.Projects.FirstOrDefault(p => p.ProjectId == request.ProjectId);

            if (project != null)
            {
                try
                {
                    dbContext.Projects.Remove(project);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return Results.Problem(detail: ex.Message, statusCode: 500, title: "Internal Error");
                }
            }
            return Results.Ok();
        }
    }
    public class RemoveProjectValidator : AbstractValidator<ProjectRemoveRequest>
    {
        private readonly TaskManagerDbContext dbContext;

        public RemoveProjectValidator(TaskManagerDbContext dbContext)
        {
            this.dbContext = dbContext;

            RuleFor(x => HasAnyPendingTasks(x.ProjectId))
                .Equal(true)
                .WithMessage("Projeto contém Tarefas pendentes. Conclua ou remova as Tarefas antes de remover o Projeto");
        }

        private bool HasAnyPendingTasks(int projectId)
        {
            return
                dbContext.Projects
                .First(p => p.ProjectId == projectId)
                .WorkTasks
                .Where(wt => wt.Status == WorkTaskStatus.Pending)
                .Any();
        }
    }
}
