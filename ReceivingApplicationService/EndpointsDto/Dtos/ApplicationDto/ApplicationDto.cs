using Entities;

namespace HttpDto.Dtos.ApplicationDto;

public record ApplicationDto(
    Guid ApplicationId, Guid AuthorId, ActivityType ActivityType, string Name, string Description,
    string Outline, TimeSpan? OnViewing, TimeSpan? IsDraft, TimeSpan? IsApproved){}