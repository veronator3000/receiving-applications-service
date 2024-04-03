using Entities;
using HttpDto.Dtos.UpdateApplicationDto;

namespace HttpDto.Mappers.ApplicationRouteMappers;

public static class UpdatingApplicationMapper
{
    public static Application MapToEntityApplication(UpdateApplicationRequestDto dto)
    {
        return new Application
        {
            ActivityType = ActivityType.Discussion,
            Name = dto.Name,
            Description = dto.Description,
            Outline = dto.Outline,
        };
    }

    public static UpdateApplicationResponseDto MapToResponseDto(Application entity)
    {
        return new UpdateApplicationResponseDto(
            entity.ApplicationId,
            entity.AuthorId,
            entity.ActivityType.ToString(),
            entity.Name,
            entity.Description,
            entity.Outline
        );
    }
}