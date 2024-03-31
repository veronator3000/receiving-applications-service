using Entities;

namespace HttpDto.Dtos.UpdateApplicationDto;

public record UpdateApplicationResponseDto(
    Guid ApplicationId, Guid AuthorId, ActivityType Activity, string Name, string Description, string Outline) {}