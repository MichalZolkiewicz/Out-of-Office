using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAllAsync(string sortField, bool ascending, string filterBy);
    Task<User> GetByIdAsync(string id);
    Task<User> AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}
