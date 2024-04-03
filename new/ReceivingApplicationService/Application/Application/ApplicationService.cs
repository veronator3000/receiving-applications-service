using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Abstractions.Repositories;
using Contracts.ResultInfo;
using HttpDto.Dtos.ApplicationDto;
using HttpDto.Dtos.CreateApplicationDto;
using HttpDto.Dtos.UpdateApplicationDto;
using HttpDto.Mappers.ApplicationMapper;
using HttpDto.Mappers.ApplicationRouteMappers;

namespace Application.Application;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }
    
    public async Task<CreateApplicationResponseDto> CreateApplication(CreateApplicationRequestDto applicationRequestDto)
    {
        var applicationEntity = CreatingApplicationMapper.MapToEntityApplication(applicationRequestDto);
        var res = _applicationRepository.CreateApplication(applicationEntity);
        var response = CreatingApplicationMapper.MapToResponseDto(await res);
        return response;
    }

    public async Task<UpdateApplicationResponseDto> UpdateApplication(Guid id,
        UpdateApplicationRequestDto applicationRequestDto)
    {
        var applicationEntity = UpdatingApplicationMapper.MapToEntityApplication(applicationRequestDto);
        var findRes = await _applicationRepository.GetApplicationById(id);
        findRes.ActivityType = applicationEntity.ActivityType;
        findRes.Name = applicationEntity.Name;
        findRes.Description = applicationEntity.Description;
        findRes.Outline = applicationEntity.Outline;
        var res = _applicationRepository.UpdateApplication(findRes);
        var response = UpdatingApplicationMapper.MapToResponseDto(await res);
        return response;
    }
    public async Task<SubmitResult> SubmitApplication(Guid id)
    {
        var application = await _applicationRepository.GetApplicationById(id);
        if (application == null)
        {
            return new SubmitResult.Failed();
        }
        if (application.AuthorId == Guid.Empty || 
            application.ActivityType == default || 
            string.IsNullOrEmpty(application.Name) || 
            string.IsNullOrEmpty(application.Outline))
        {
            return new SubmitResult.Failed();
        }
        application.OnViewing = DateTime.UtcNow;
        await _applicationRepository.UpdateApplication(application);

        return new SubmitResult.Success();
        
    }

    public async Task<DeleteResult> DeleteApplication(Guid id)
    {
        var application = await _applicationRepository.GetApplicationById(id);
        if (application == null)
        {
            return new DeleteResult.Failed();
        }

        if (application.IsApproved == null && application.OnViewing != null)
        {
            return new DeleteResult.Failed();
        }
        await _applicationRepository.DeleteApplication(id);
        return new DeleteResult.Success();
    }

   
    public async Task<IEnumerable<ApplicationDto>> GetApplicationsSubmittedAfterDate(DateTime submitted)
    {
        var applications = await _applicationRepository.GetApplicationsSubmittedAfterDate(submitted);
        return applications.Select(ApplicationMapper.MapToApplicationDto).ToList();
    }

    public async Task<IEnumerable<ApplicationDto>> GetApplicationsNotSubmittedAndOlderThanDate(DateTime submitted)
    {
        var applications = await _applicationRepository.GetApplicationsNotSubmittedAndOlderThanDate(submitted);
        return applications.Select(ApplicationMapper.MapToApplicationDto).ToList();
    }

    public async Task<ApplicationDto> GetApplicationById(Guid id)
    {
        var application = await _applicationRepository.GetApplicationById(id);
        application = application ?? throw new ArgumentNullException(nameof(application));
        return ApplicationMapper.MapToApplicationDto(application);
    }
}