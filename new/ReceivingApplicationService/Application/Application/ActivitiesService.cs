using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abstractions.Repositories;
using HttpDto.Dtos;
using HttpDto.Dtos.ActivityTypesDto;
using HttpDto.Mappers.ActivitiesRouteMappers;

namespace Application.Application;

using Contracts;
public class ActivitiesService : IActivitiesService
{
    private IActivityRepository _activityRepository;
    public ActivitiesService(IActivityRepository activityRepository)
    {
        _activityRepository = activityRepository;
    }

    public async Task<IEnumerable<ActivitiesTypesResponseDto>> GetActivityTypes()
    {
        var activities = await _activityRepository.GetAllActivities();
        return ActivitiesListMapper.MapToResponseDto(activities);

    }
}