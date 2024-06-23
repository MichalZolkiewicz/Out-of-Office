using Application.Dto.Projects;

namespace Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto> GetProjectByIdAsync(int id);
    Task<ProjectDto> AddProjectAsync(CreateProjectDto newProject);
    Task UpdateProjectAsync(UpdateProjectDto updatedProject);
    Task DeleteProjectAsync(int id);
}
