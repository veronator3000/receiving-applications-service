using Contracts;
using HttpDto.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers;

[ApiController]
[Route("activities")]
public class ActivitiesController
{
    private readonly IActivitiesService _activitiesService;

    public ActivitiesController(IActivitiesService activitiesService)
    {
        _activitiesService = activitiesService;
    }

    [HttpGet]
    [Route("")]
    public async Task<ResponseDto> GetActivitiesType(ApplicationRequestDto applicationRequestDto)
    {
        var activitiesTypes = await _activitiesService.GetActivityTypes(applicationRequestDto);
        return activitiesTypes;
    }
}