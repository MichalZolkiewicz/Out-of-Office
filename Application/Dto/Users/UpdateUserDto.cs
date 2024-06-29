namespace Application.Dto.Users;

public class UpdateUserDto
{
    public string Id { get; set; }
    public string Position { get; set; }
    public string Subdivision { get; set; }
    public int AbsenceBalance { get; set; }
    public bool ActiveEmployee { get; set; }
    public int PeoplePartnerId { get; set; }
}
