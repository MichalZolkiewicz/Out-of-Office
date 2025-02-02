﻿using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.LeaveRequests;

public class LeaveRequestDto : IMap
{
    public int Id { get; set; }
    public string UserId { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<LeaveRequest, LeaveRequestDto>();
    }
}
