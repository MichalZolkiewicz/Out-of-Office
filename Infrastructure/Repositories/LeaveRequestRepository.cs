using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LeaveRequestRepository : ILeaveRequestRepository
{
    private readonly OutOfOfficeContext _context;

    public LeaveRequestRepository(OutOfOfficeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LeaveRequest>> GetAllAsync(string sortField, bool ascending, string filterBy)
    {
        return await _context.LeaveRequests
            .Where(x => x.UserId.ToString().ToLower().Contains(filterBy.ToLower()) || x.Status.ToLower().Contains(filterBy.ToLower()))
            .OrderByPropertyName(sortField, ascending)
            .ToListAsync();
    }

    public async Task<LeaveRequest> GetByIdAsync(int id)
    {
        return await _context.LeaveRequests.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest)
    {
        var createdLeaveRequest = await _context.AddAsync(leaveRequest);
        await _context.SaveChangesAsync();
        return createdLeaveRequest.Entity;
    }

    public async Task UpdateAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Update(leaveRequest);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Remove(leaveRequest);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task ChangeStatusAsync(LeaveRequest leaveRequest)
    {
        _context.LeaveRequests.Update(leaveRequest);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}
