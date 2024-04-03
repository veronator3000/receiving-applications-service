using System.Collections.Generic;

namespace HttpDto.Dtos.GetApplicationsByDate;

public record GetApplicationsByDateResponseDto(IList<ApplicationDto.ApplicationDto> Applications) {}