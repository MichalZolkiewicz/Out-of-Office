using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private readonly UserManager<User> _userManager;
    private readonly OutOfOfficeContext _context;

    public UserRepository(UserManager<User> userManager, OutOfOfficeContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    public IEnumerable<User> GetAllAsync(string sortField, bool ascending, string filterBy)
    {
        return _context.Users
            .Where(x => x.FullName.ToLower().Contains(filterBy.ToLower()) || x.Subdivision.ToLower().Contains(filterBy.ToLower())
            || x.Position.ToLower().Contains(filterBy.ToLower()))
            .OrderByPropertyName(sortField, ascending)
            .ToList();
    }
}
