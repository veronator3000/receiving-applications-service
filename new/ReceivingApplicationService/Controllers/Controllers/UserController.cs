using System;
using System.Threading.Tasks;
using Contracts;
using HttpDto.Dtos.ApplicationDto;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers;

[ApiController]
[Route("users")]
public class UserController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    [HttpGet]
    public Task<ApplicationDto> GetApplicationsByUserId(Guid userId)
    {
        return _userService.GetMyDraftApplication(userId);
    }
}