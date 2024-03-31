using System.Diagnostics;
using System.Net.Mime;
using Contracts.ResultInfo;
using Entities;
using HttpDto.Dtos;
using HttpDto.Dtos.ApplicationDto;
using HttpDto.Dtos.CreateApplicationDto;
using HttpDto.Dtos.UpdateApplicationDto;

namespace Contracts;

public interface IApplicationService
{
    Task<CreateApplicationResponseDto> CreateApplication(CreateApplicationRequestDto applicationRequestDto);
    Task<UpdateApplicationResponseDto> UpdateApplication(Guid id, UpdateApplicationResponseDto applicationRequestDto);
    Task<DeleteResult> DeleteApplication(Guid id);
    Task<SubmitResult> SubmitApplication(Guid id);
    Task<IEnumerable<ApplicationDto>> GetApplications(DateTime? submitted, DateTime? unsubmitted);
    Task<ApplicationDto> GetCurrentApplicationForUser(Guid userId);
    Task<Application> GetApplicationById(Guid id);
}