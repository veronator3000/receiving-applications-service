using Entities;
using HttpDto.Dtos.CreateApplicationDto;

namespace HttpDto.Mappers.ApplicationRouteMappers;

public static class CreatingApplicationMapper
{
    public static Application MapToEntityApplication(CreateApplicationRequestDto dto)
    {
        return new Application
        {
            AuthorId = dto.AuthorId,
            ActivityType = ActivityType.Discussion,
            Name = dto.Name,
            Description = dto.Description,
            Outline = dto.Outline,
        };
    }

    public static CreateApplicationResponseDto MapToResponseDto(Application entity)
    {
        return new CreateApplicationResponseDto (
            entity.ApplicationId,
            entity.AuthorId,
            entity.ActivityType.ToString(),
            entity.Name,
            entity.Description,
            entity.Outline
        );
    }
}