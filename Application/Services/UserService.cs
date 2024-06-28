using Application.Dto.Users;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
}
