using HttpDto.Dtos;

namespace Contracts;

public interface IActivitiesService
{
    Task<ResponseDto> GetActivityTypes(RequestDto requestDto);
}