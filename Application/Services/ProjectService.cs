using Application.Dto.Project;
using Application.Interfaces;

namespace Application.Services;

internal class ProjectService : IProjectService
{
    public Task<ProjectDto> AddApprovalRequestAsync(CreateProjectDto project)
    {
        throw new NotImplementedException();
    }

    public Task DeleteApprovalRequestAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProjectDto>> GetAllApprovalRequestsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDto> GetApprovalRequestsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateApprovalRequestAsync(UpdateProjectDto project)
    {
        throw new NotImplementedException();
    }
}
