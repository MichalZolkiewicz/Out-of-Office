using Application.Dto.Users;

namespace Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersSortedAndFilteredAsync(string sortField, bool ascending, string filterBy);

    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(string id);
    Task<UserDto> AddUserAsync(CreateUserDto newUser);
    Task UpdateUserAsync(UpdateUserDto updatedUser);
    Task DeleteUserAsync(string id);
    Task UpdateUserAbsenceBalanceAsync(UserDto userDto, int daysOfLeave);
}
