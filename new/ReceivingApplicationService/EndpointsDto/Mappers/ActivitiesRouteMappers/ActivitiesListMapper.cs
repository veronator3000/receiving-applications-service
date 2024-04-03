using System.Collections.Generic;
using System.Linq;
using Entities.ActivitySet;
using HttpDto.Dtos.ActivityTypesDto;

namespace HttpDto.Mappers.ActivitiesRouteMappers;

public static class ActivitiesListMapper
{
    public static IEnumerable<ActivitiesTypesResponseDto> MapToResponseDto(IEnumerable<ActivityEntity> activityEntities)
    {
        return activityEntities.Select(activityEntity =>
            new ActivitiesTypesResponseDto
            (
                activityEntity.Type.ToString(),
                activityEntity.Description
            ));
    }
}