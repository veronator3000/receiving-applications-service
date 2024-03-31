using Entities;

namespace HttpDto.Dtos.CreateApplicationDto;

public record CreateApplicationRequestDto(
    Guid AuthorId, ActivityType Activity, string Name, string Description, string Outline) {}