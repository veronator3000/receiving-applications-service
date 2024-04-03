using System.Collections.Generic;
using System.Threading.Tasks;
using HttpDto.Dtos;
using HttpDto.Dtos.ActivityTypesDto;

namespace Contracts;

public interface IActivitiesService
{
    Task<IEnumerable<ActivitiesTypesResponseDto>> GetActivityTypes();
}