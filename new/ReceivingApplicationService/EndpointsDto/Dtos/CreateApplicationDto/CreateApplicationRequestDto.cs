using System;
using Entities;

namespace HttpDto.Dtos.CreateApplicationDto;

public record CreateApplicationRequestDto(
    Guid AuthorId, string Activity, string Name, string Description, string Outline) {}