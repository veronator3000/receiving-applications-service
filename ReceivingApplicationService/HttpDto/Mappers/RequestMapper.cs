
using Entities;
using HttpDto.Dtos;

namespace HttpDto.Mappers;

public class RequestMapper
{
    public Application MapToApplication(RequestDto requestDto)
    {
        return new Application
        {
            AuthorId = requestDto.Author,
            ActivityType = requestDto.Activity,
            Name = requestDto.Name,
            Description = requestDto.Description,
            Outline = requestDto.Outline
        };
    }
}