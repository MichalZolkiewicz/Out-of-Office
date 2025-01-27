﻿using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ApprovalRepository : IApprovalRepository
{

    private readonly OutOfOfficeContext _context;

    public ApprovalRepository(OutOfOfficeContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ApprovalRequest>> GetAllAsync(string sortField, bool ascending, string filterBy)
    {
        return await _context.ApprovalRequests
            .Where(x => x.ApproverId.ToLower().Contains(filterBy.ToLower()) || x.Status.ToLower().Contains(filterBy.ToLower()))
            .OrderByPropertyName(sortField, ascending)
            .ToListAsync();
    }

    public async Task<ApprovalRequest> GetByIdAsync(int id)
    {
        return await _context.ApprovalRequests.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ApprovalRequest> AddAsync(ApprovalRequest approvalRequest)
    {
        var createdApproval = await _context.AddAsync(approvalRequest);
        await _context.SaveChangesAsync();
        return createdApproval.Entity;
    }

    public async Task UpdateAsync(ApprovalRequest approvalRequest)
    {
        _context.ApprovalRequests.Update(approvalRequest);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(ApprovalRequest approvalRequest)
    {
        _context.ApprovalRequests.Remove(approvalRequest);
        await _context.SaveChangesAsync();
        await Task.CompletedTask;
    }
}
