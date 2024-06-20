using Application.Dto.Projects;
using Application.Interfaces;

namespace Application.Services;

internal class ProjectService : IProjectService
{
    public Task<ProjectDto> AddProjectAsync(CreateProjectDto project)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProjectAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDto> GetProjectByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateProjectAsync(UpdateProjectDto project)
    {
        throw new NotImplementedException();
    }
}
