using Domain.Entities;

namespace Domain.Interfaces;

public interface IUserRepository
{
    IEnumerable<User> GetAllAsync(string sortField, bool ascending, string filterBy);
}
