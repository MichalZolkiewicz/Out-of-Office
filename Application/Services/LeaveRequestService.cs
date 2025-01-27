﻿using Application.Dto.LeaveRequests;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class LeaveRequestService : ILeaveRequestService
{

    private readonly ILeaveRequestRepository _leaveRequestRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public LeaveRequestService(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, IUserService userService)
    {
        _leaveRequestRepository = leaveRequestRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<IEnumerable<LeaveRequestDto>> GetAllLeaveRequestsAsync(string sortField, bool ascending, string filterBy)
    {
        var leaves = await _leaveRequestRepository.GetAllAsync(sortField, ascending, filterBy);
        return _mapper.Map<IEnumerable<LeaveRequestDto>>(leaves); 
    }

    public async Task<LeaveRequestDto> GetLeaveRequestByIdAsync(int id)
    {
        var leave = await _leaveRequestRepository.GetByIdAsync(id);
        return _mapper.Map<LeaveRequestDto>(leave);
    }

    public async Task<LeaveRequestDto> AddLeaveRequestAsync(CreateLeaveRequestDto newLeaveRequest)
    {
        var leave = _mapper.Map<LeaveRequest>(newLeaveRequest);
        var result = await _leaveRequestRepository.AddAsync(leave);
        return _mapper.Map<LeaveRequestDto>(result);
    }

    public async Task UpdateLeaveRequestAsync(UpdateLeaveRequestDto updatedLeaveRequest)
    {
        var existingLeave = await _leaveRequestRepository.GetByIdAsync(updatedLeaveRequest.Id);
        var leave = _mapper.Map(updatedLeaveRequest, existingLeave);
        await _leaveRequestRepository.UpdateAsync(leave);
    }

    public async Task DeleteLeaveRequestAsync(int id)
    {
        var leave = await _leaveRequestRepository.GetByIdAsync(id);
        await _leaveRequestRepository.DeleteAsync(leave);
    }

    public async Task ChangeStatusOfLeaveRequestAsync(ChangeStatusLeaveRequestDto changeStatusLeaveRequest)
    {
        var existingLeave = await _leaveRequestRepository.GetByIdAsync(changeStatusLeaveRequest.Id);

        if(changeStatusLeaveRequest.Status == "Approved")
        {
            var userDto = await _userService.GetUserByIdAsync(existingLeave.UserId);
            var daysOfLeave = (int)(existingLeave.EndDate - existingLeave.StartDate).TotalDays;
            await _userService.UpdateUserAbsenceBalanceAsync(userDto, daysOfLeave);
        }
        var leave = _mapper.Map(changeStatusLeaveRequest, existingLeave);
        await _leaveRequestRepository.UpdateAsync(leave);
    }
}
