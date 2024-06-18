﻿using Application.Dto.ApprovalRequest;

namespace Application.Interfaces;

public interface IApprovalRequestService
{
    Task<IEnumerable<ApprovalRequestDto>> GetAllApprovalRequestsAsync();
    Task<ApprovalRequestDto> GetApprovalRequestsByIdAsync(int id);
    Task<ApprovalRequestDto> AddApprovalRequestAsync(CreateApprovalRequestDto approvalRequest);
    Task UpdateApprovalRequestAsync(UpdateApprovalRequestDto approvalRequest);
    Task DeleteApprovalRequestAsync(int id);
}
