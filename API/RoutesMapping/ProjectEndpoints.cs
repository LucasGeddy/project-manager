using Microsoft.AspNetCore.Mvc;
using project_manager.Application.Interfaces.Project;

namespace project_manager.API.RoutesMapping
{
    public static class ProjectEndpoints
    {
        public static WebApplication? MapProjectEndpoints(this WebApplication? app)
        {
            var projectRoute = "/project";

            app.MapGet($"{projectRoute}:{{userId}}", (IGetProjectService projectService, [FromRoute] int userId) =>
            {
                return projectService.GetAllProjectsAsync(userId);
            })
            .WithName("GetAllProjects")
            .WithOpenApi();

            app.MapPost(projectRoute, async (ICreateProjectService projectService, [FromBody] ProjectCreateRequest request) =>
            {
                return await projectService.CreateProjectAsync(request);
            })
            .WithName("CreateProject")
            .WithOpenApi();

            app.MapDelete($"{projectRoute}:{{projectId}}", async (IRemoveProjectService projectService, [FromRoute] ProjectRemoveRequest request) =>
            {
                return await projectService.RemoveProjectAsync(request);
            })
            .WithName("RemoveProject")
            .WithOpenApi();

            return app;
        }
    }
}
