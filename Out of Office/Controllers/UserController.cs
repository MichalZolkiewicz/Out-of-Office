using Application.Dto.Users;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Out_of_Office.Filters;
using Out_of_Office.Filters.Helpers;
using Out_of_Office.Wrapper;
using Swashbuckle.AspNetCore.Annotations;

namespace Out_of_Office.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{ 
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IUserService userService)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _userService = userService;
    }

    [SwaggerOperation(Summary = "Retireves sort fields")]
    [HttpGet("[action]")]
    public IActionResult GetSortFields()
    {
        return Ok(SortingHelper.GetUsersSortFields().Select(x => x.Key));
    }

    [SwaggerOperation(Summary = "Retrieves all employees")]
    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetUsers([FromQuery] UserSortingFilter sortingFilter, [FromQuery] string filterBy = "")
    {
        var validSortingFilter = new UserSortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

        var users = await _userService.GetAllUsersAsync(validSortingFilter.SortField, validSortingFilter.Ascending, filterBy);
        if (users == null)
        {
            return NotFound();
        }

        return Ok(users);
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
            ActiveEmployee = createUser.ActiveEmployee,
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

    [SwaggerOperation(Summary = "Change user role to manager")]
    [HttpPut]
    [Route("ManagerPromotion/{userName}")]
    public async Task<IActionResult> UpdateUserToManagerAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if(user == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "User does not exist!"
            });
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.Manager))
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Manager));
        }

        await _userManager.RemoveFromRoleAsync(user, UserRoles.Employee);
        await _userManager.AddToRoleAsync(user, UserRoles.Manager);         

        return Ok(new Response { Succeeded = true, Message = "User role updated to Manager" });
    }

    [SwaggerOperation(Summary = "Change user role to project manager")]
    [HttpPut]
    [Route("ProjectManagerPromotion/{userName}")]
    public async Task<IActionResult> UpdateUserToProjectManagerAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "User does not exist!"
            });
        }

        if (!await _roleManager.RoleExistsAsync(UserRoles.ProjectManager))
        {
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.ProjectManager));
        }

        await _userManager.RemoveFromRoleAsync(user, UserRoles.Employee);
        await _userManager.AddToRoleAsync(user, UserRoles.ProjectManager);

        return Ok(new Response { Succeeded = true, Message = "User role updated to Project Manager" });
    }

    [SwaggerOperation(Summary = "Change active status of user")]
    [HttpPut]
    [Route("ChangeActiveStatus/{status}")]
    public async Task<IActionResult> UpdateUserStatusAsync(string userName, bool status)
    {
        var existsingUser = await _userManager.FindByNameAsync(userName);
        if(existsingUser == null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response
            {
                Succeeded = false,
                Message = "User does not exist!"
            });
        }
        
        existsingUser.ActiveEmployee = status;
        await _userManager.UpdateAsync(existsingUser);
        

        return Ok(new Response { Succeeded = true, Message = "User status changed" });
    }
}
