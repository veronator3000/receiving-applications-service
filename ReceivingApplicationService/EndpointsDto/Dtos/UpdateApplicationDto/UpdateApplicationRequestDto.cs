using Entities;

namespace HttpDto.Dtos.UpdateApplicationDto;

public record UpdateApplicationRequestDto(
    ActivityType ActivityType, string Name, string Description, string Outline) {}
