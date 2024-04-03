using Entities;
using HttpDto.Dtos.ApplicationDto;

namespace HttpDto.Mappers.ApplicationMapper;

public class ApplicationMapper
{
    public static Application MapToEntity(ApplicationDto applicationDto)
    {
        return new Application
        {
            ApplicationId = applicationDto.ApplicationId,
            AuthorId = applicationDto.AuthorId,
            ActivityType = applicationDto.ActivityType,
            Name = applicationDto.Name,
            Description = applicationDto.Description,
        };
    }
    public static ApplicationDto MapToApplicationDto(Application application)
    {
        return new ApplicationDto(
            application.ApplicationId,
            application.AuthorId,
            application.ActivityType,
            application.Name,
            application.Description,
            application.Outline
        );
    }
}