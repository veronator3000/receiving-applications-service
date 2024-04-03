using Entities;

namespace HttpDto.Dtos.UpdateApplicationDto;

public record UpdateApplicationRequestDto(
    string ActivityType, string Name, string Description, string Outline) {}
