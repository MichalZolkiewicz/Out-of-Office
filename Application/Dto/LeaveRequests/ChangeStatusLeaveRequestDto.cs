using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.LeaveRequests;

public class ChangeStatusLeaveRequestDto : IMap
{
    public int Id { get; set; }
    public string Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ChangeStatusLeaveRequestDto, LeaveRequest>();
    }
}
