using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProjectRepository : IProjectRepository
{

    private readonly OutOfOfficeContext _context;

    public ProjectRepository(OutOfOfficeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> GetByIdAsync(int id)
    {
        return await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Project> AddAsync(Project project)
    {
        var createdProject = await _context.AddAsync(project);
        await _context.SaveChangesAsync();
        return createdProject.Entity;
    }

    public async Task UpdateAsync(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Project project)
    {
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}
