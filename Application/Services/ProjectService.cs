using Application.Dto.Projects;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

internal class ProjectService : IProjectService
{

    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync(string sortField, bool ascending, string filterBy)
    {
        var projects = await _projectRepository.GetAllAsync(sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<ProjectDto> GetProjectByIdAsync(int id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> AddProjectAsync(CreateProjectDto newProject, string projectManagerId)
    {
        var project = _mapper.Map<Project>(newProject);
        project.ProjectManagerId = projectManagerId;
        var result = await _projectRepository.AddAsync(project);
        return _mapper.Map<ProjectDto>(result);
    }

    public async Task UpdateProjectAsync(UpdateProjectDto updatedProject)
    {
        var existingProject = await _projectRepository.GetByIdAsync(updatedProject.Id);
        var project = _mapper.Map(updatedProject, existingProject);
        await _projectRepository.UpdateAsync(project);
    }

    public async Task DeleteProjectAsync(int id)
    {
        var post = await _projectRepository.GetByIdAsync(id);
        await _projectRepository.DeleteAsync(post);
    }
}
