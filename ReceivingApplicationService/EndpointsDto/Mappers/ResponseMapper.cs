using Entities;
using HttpDto.Dtos;

namespace HttpDto.Mappers;

public class ResponseMapper
{
    public ResponseDto MapToResponseDto(Application application)
    {
        return new ResponseDto
        {
            Id = application.ApplicationId,
            Author = application.AuthorId,
            Activity = application.ActivityType,
            Name = application.Name,
            Description = application.Description,
            Outline = application.Outline
        };
    }
}