namespace project_manager.Application.Interfaces.Project
{
    public record ProjectGetResponse(int ProjectId, string Title, string UserName);
    public interface IGetProjectService
    {
        Task<IResult> GetAllProjectsAsync(int userId);
    }
}
