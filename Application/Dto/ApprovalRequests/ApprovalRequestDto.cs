using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.ApprovalRequests;

public class ApprovalRequestDto : IMap
{

    public int Id { get; set; }
    public string ApproverId { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ApprovalRequest, ApprovalRequestDto>();
    }
}