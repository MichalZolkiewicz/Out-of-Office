using Application.Dto.Users;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Out_of_Office.Wrapper;

namespace Out_of_Office.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{ 
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public IdentityController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> RegisterAsync(CreateUserDto createUser)
    {
        var userExists = await _roleManager.FindByNameAsync(createUser.UserName);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "User already exists!"
            });
        }

        var user = new User
        {
            UserName = createUser.UserName,
            Email = createUser.Email,
            FullName = createUser.FullName,
            Position = createUser.Position,
            Subdivision = createUser.Subdivision,
            AbsenceBalance = createUser.AbsenceBalance,
        };

        var result = await _userManager.CreateAsync(user, createUser.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response<bool>
            {
                Succeeded = false,
                Message = "User creation failed! Please check login details and try again",
                Errors = result.Errors.Select(x => x.Description)
            });
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.Employee))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));

        await _userManager.AddToRoleAsync(user, UserRoles.Employee);

        return Ok(new Response { Succeeded = true, Message = "User created successfuly!" });
    }
}
