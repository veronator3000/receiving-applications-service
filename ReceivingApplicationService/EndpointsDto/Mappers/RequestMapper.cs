
using Entities;
using HttpDto.Dtos;

namespace HttpDto.Mappers;

public class RequestMapper
{
    public Application MapToApplication(ApplicationRequestDto applicationRequestDto)
    {
        return new Application
        {
            AuthorId = applicationRequestDto.Author,
            ActivityType = applicationRequestDto.Activity,
            Name = applicationRequestDto.Name,
            Description = applicationRequestDto.Description,
            Outline = applicationRequestDto.Outline
        };
    }
}