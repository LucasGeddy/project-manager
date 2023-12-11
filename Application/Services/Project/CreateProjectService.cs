using FluentValidation;
using project_manager.Application.Interfaces.Project;
using task_manager_challenge.Infrastructure;
using Entities = project_manager.Domain.Entities;

namespace project_manager.Application.Services.Project
{
    public class CreateProjectService : ICreateProjectService
    {
        private readonly TaskManagerDbContext dbContext;
        private readonly IValidator<ProjectCreateRequest> validator;
        public CreateProjectService(TaskManagerDbContext dbContext, IValidator<ProjectCreateRequest> validator)
        {
            this.dbContext = dbContext;
            this.validator = validator;
        }
        public async Task<IResult> CreateProjectAsync(ProjectCreateRequest request)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Results.BadRequest(validationResult.ToString());

            try
            {
                var project = CreateProjectFromRequest(request);
                dbContext.Add(project);

                await dbContext.SaveChangesAsync();
                return Results.Created();
            }
            catch (Exception ex)
            {
                return Results.Problem(detail: ex.Message, statusCode: 500, title: "Internal Error");
            }
        }

        private static Entities.Project CreateProjectFromRequest(ProjectCreateRequest request)
        {
            return new Entities.Project()
            {
                Title = request.Title,
                UserId = request.UserId
            };
        }
    }
    public class CreateProjectValidator : AbstractValidator<ProjectCreateRequest>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotNull();
            RuleFor(x => x.UserId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}