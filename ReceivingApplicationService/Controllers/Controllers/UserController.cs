using Contracts;
using HttpDto.Dtos;
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
    [Route("users/{userId}/currentapplication")]
    public async Task<ResponseDto> GetMyDraftApplication(RequestDto requestDto)
    {
        var draftApplication = await _userService.GetMyDraftApplication(requestDto);
        return draftApplication;
    }

}