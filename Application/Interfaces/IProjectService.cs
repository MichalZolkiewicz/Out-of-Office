using Application.Dto.LeaveRequest;
using Application.Dto.Project;

namespace Application.Interfaces;

public interface IProjectService
{
    Task<IEnumerable<ProjectDto>> GetAllApprovalRequestsAsync();
    Task<ProjectDto> GetApprovalRequestsByIdAsync(int id);
    Task<ProjectDto> AddApprovalRequestAsync(CreateProjectDto project);
    Task UpdateApprovalRequestAsync(UpdateProjectDto project);
    Task DeleteApprovalRequestAsync(int id);
}
