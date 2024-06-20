using Application.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Dto.Projects;

public class UpdateProjectDto : IMap
{
    public int Id { get; set; }
    public DateTime EndDate { get; set; }
    public int ProjectManagerId { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProjectDto, Project>();
    }
}
