using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using HttpDto.Dtos;
using HttpDto.Dtos.ActivityTypesDto;
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
    public async Task<IEnumerable<ActivitiesTypesResponseDto>> GetActivitiesType()
    {
        var activitiesTypes = await _activitiesService.GetActivityTypes();
        return activitiesTypes;
    }
}