namespace project_manager.Application.Interfaces.Project
{
    public record ProjectCreateRequest(string Title, int UserId);
    public interface ICreateProjectService
    {
        Task<IResult> CreateProjectAsync(ProjectCreateRequest request);
    }
}
