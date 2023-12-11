namespace project_manager.Application.Interfaces.Project
{
    public record ProjectRemoveRequest(int ProjectId);
    public interface IRemoveProjectService
    {
        Task<IResult> RemoveProjectAsync(ProjectRemoveRequest request);
    }
}
