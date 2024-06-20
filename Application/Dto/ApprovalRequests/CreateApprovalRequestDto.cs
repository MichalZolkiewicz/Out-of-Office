using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ApprovalRequests;

public class CreateApprovalRequestDto : IMap
{
    public int ApproverId { get; set; }
    public int LeaveRequestId { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateApprovalRequestDto, ApprovalRequest>();
    }
}
