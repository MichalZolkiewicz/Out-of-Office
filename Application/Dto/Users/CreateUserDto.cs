namespace Application.Dto.Users;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Position { get; set; }
    public string Subdivision { get; set; }
    public int AbsenceBalance { get; set; }
}
