using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading.Tasks;
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
    Task<UpdateApplicationResponseDto> UpdateApplication(Guid id, UpdateApplicationRequestDto applicationRequestDto);
    Task<DeleteResult> DeleteApplication(Guid id);
    Task<SubmitResult> SubmitApplication(Guid id);
    Task<IEnumerable<ApplicationDto>> GetApplicationsSubmittedAfterDate(DateTime submitted);
    Task<IEnumerable<ApplicationDto>> GetApplicationsNotSubmittedAndOlderThanDate(DateTime submitted);

    Task<ApplicationDto> GetApplicationById(Guid id);
}