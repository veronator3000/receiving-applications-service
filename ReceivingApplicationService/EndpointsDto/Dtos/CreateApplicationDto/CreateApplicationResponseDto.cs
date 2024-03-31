using Entities;

namespace HttpDto.Dtos.CreateApplicationDto;

public record CreateApplicationResponseDto (
    Guid ApplicationId, Guid AuthorId, ActivityType Activity, string Name, string Description, string Outline) {}