using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Users;

public class UserDto : IMap
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Subdivision { get; set; }
    public int PeoplePartnerId { get; set; }
    public bool ActiveEmployee { get; set; }
    public int AbsenceBalance { get; set; }
    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDto>();
        profile.CreateMap<UserDto, User>();
    }
}
