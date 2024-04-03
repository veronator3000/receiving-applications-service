using System;
using Entities;

namespace HttpDto.Dtos.UpdateApplicationDto;

public record UpdateApplicationResponseDto(
    Guid ApplicationId, Guid AuthorId, string Activity, string Name, string? Description, string Outline) {}