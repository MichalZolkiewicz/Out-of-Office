using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Projects;

public class CreateProjectDto : IMap
{
    public string ProjectType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProjectDto, Project>();
    }
}
