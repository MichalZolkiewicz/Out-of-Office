using Application.Dto.ApprovalRequests;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ApprovalRequestService : IApprovalRequestService
{

    private readonly IApprovalRepository _approvalRepository;
    private readonly IMapper _mapper;

    public ApprovalRequestService(IApprovalRepository approvalRepository, IMapper mapper)
    {
        _approvalRepository = approvalRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ApprovalRequestDto>> GetAllApprovalRequestsAsync()
    {
        var approvals = await _approvalRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ApprovalRequestDto>>(approvals);
    }

    public async Task<ApprovalRequestDto> GetApprovalRequestByIdAsync(int id)
    {
        var approval = await _approvalRepository.GetByIdAsync(id);
        return _mapper.Map<ApprovalRequestDto>(approval);
    }
    public async Task<ApprovalRequestDto> AddApprovalRequestAsync(CreateApprovalRequestDto newApprovalRequest)
    {
        var approval = _mapper.Map<ApprovalRequest>(newApprovalRequest);
        var result = await _approvalRepository.AddAsync(approval);
        return _mapper.Map<ApprovalRequestDto>(result);
    }

    public async Task UpdateApprovalRequestAsync(UpdateApprovalRequestDto updatedApprovalRequest)
    {
        var existingApproval = await _approvalRepository.GetByIdAsync(updatedApprovalRequest.Id);
        var approval = _mapper.Map(updatedApprovalRequest, existingApproval);
        await _approvalRepository.UpdateAsync(approval);
    }

    public async Task DeleteApprovalRequestAsync(int id)
    {
        var approval = await _approvalRepository.GetByIdAsync(id);
        await _approvalRepository.DeleteAsync(approval);
    }
}
