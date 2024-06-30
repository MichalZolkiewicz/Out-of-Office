using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Out_of_Office.Filters.Helpers;
using Out_of_Office.Filters;
using Swashbuckle.AspNetCore.Annotations;
using Application.Dto.Projects;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Out_of_Office.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [SwaggerOperation(Summary = "Retireves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetProjectsSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Get list of all projects")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet("[action]")]
    public async Task<IActionResult> GetAllProjectsAsync([FromQuery] ProjectSortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validSortingFilter = new ProjectSortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var projects = _projectService.GetAllProjectsAsync(validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        if (projects == null)
        {
            return NotFound();
        }

        return Ok(projects);
    }

    [SwaggerOperation(Summary = "Retrieves project by id")]
    [Authorize(Roles = UserRoles.Manager + "," + UserRoles.ProjectManager)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectByIdAsync(int id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [SwaggerOperation(Summary = "Add project to database")]
    [Authorize(Roles = UserRoles.ProjectManager)]
    [HttpPost]
    public async Task<IActionResult> AddProjectAsync([FromBody] CreateProjectDto createProject)
    {
        var project = await _projectService.AddProjectAsync(createProject, User.FindFirstValue(ClaimTypes.NameIdentifier));
        return Created($"api/project/{project.Id}", createProject);
    }

    [SwaggerOperation(Summary = "Update project in database")]
    [Authorize(Roles = UserRoles.ProjectManager)]
    [HttpPut]
    public async Task<IActionResult> UpdateProjectAsync([FromBody] UpdateProjectDto updateProject)
    {
        await _projectService.UpdateProjectAsync(updateProject);
        return NoContent();
    }

    [SwaggerOperation(Summary = "Remove project from database")]
    [Authorize(Roles = UserRoles.ProjectManager)]
    [HttpDelete]
    public async Task<IActionResult> DeleteProjectAsync([FromQuery] int id)
    {
        await _projectService.DeleteProjectAsync(id);
        return NoContent();
    }
}
