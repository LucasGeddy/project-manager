using FluentValidation;
using project_manager.Application.Interfaces.Project;
using project_manager.Application.Services.Project;

namespace project_manager.API.DI
{
    public static class ProjectExtensions
    {
        public static IServiceCollection AddProject(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ProjectCreateRequest>, CreateProjectValidator>();
            services.AddScoped<IValidator<ProjectRemoveRequest>, RemoveProjectValidator>();

            services.AddScoped<ICreateProjectService, CreateProjectService>();
            services.AddScoped<IRemoveProjectService, RemoveProjectService>();
            services.AddScoped<IGetProjectService, GetProjectService>();

            return services;
        }
    }
}
