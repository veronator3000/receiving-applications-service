using System;
using Entities;

namespace HttpDto.Dtos.CreateApplicationDto;

public record CreateApplicationResponseDto (
    Guid ApplicationId, Guid AuthorId, string Activity, string Name, string? Description, string Outline) {}