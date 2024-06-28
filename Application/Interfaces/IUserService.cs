using Application.Dto.Users;

namespace Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync(string sortField, bool ascending, string filterBy);
}
