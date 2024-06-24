using Domain.Entities;

namespace Domain.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAllAsync(string sortField, bool ascending, string filterBy);
    Task<Project> GetByIdAsync(int id);
    Task<Project> AddAsync (Project project);
    Task UpdateAsync (Project project);
    Task DeleteAsync (Project project);
}
