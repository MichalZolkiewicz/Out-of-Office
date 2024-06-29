using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    private readonly OutOfOfficeContext _context;

    public UserRepository(OutOfOfficeContext context)
    {
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

    public async Task<User> GetByIdAsync(string id)
    {
        return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<User> AddAsync(User user)
    {
        var createdUser = await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return createdUser.Entity;
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}
