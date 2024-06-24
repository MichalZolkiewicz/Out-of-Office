using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Employees;

public class CreateEmployeeDto : IMap
{
    public string FullName { get; set; }
    public string Subdivision {  get; set; }
    public string Position { get; set; }
    public bool ActiveEmployee { get; set; }
    public int? PeoplePartnerId { get; set; }
    public int AbsenceBalance { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateEmployeeDto, Employee>();
    }
}
