using Application.Dto.Users;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(string sortField, bool ascending, string filterBy)
    {
        var users = _userRepository.GetAllAsync(sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }

    public async Task<UserDto> GetUserByIdAsync(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> AddUserAsync(CreateUserDto newUser)
    {
        var user = _mapper.Map<User>(newUser);
        var result = await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(result);
    }

    public async Task UpdateUserAsync(UpdateUserDto updatedUser)
    {
        var existingUser = await _userRepository.GetByIdAsync(updatedUser.Id);
        var user = _mapper.Map(updatedUser, existingUser);
        await _userRepository.UpdateAsync(user);
    }

    public async Task DeleteUserAsync(string id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        await _userRepository.DeleteAsync(user);    
    }
}
