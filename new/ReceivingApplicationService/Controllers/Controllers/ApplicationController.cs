using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts;
using Contracts.ResultInfo;
using HttpDto.Dtos;
using HttpDto.Dtos.ApplicationDto;
using HttpDto.Dtos.CreateApplicationDto;
using HttpDto.Dtos.UpdateApplicationDto;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Controllers.Controllers;

[ApiController]
[Route("applications")]
public class ApplicationController
{
    private readonly IApplicationService _applicationService;

    public ApplicationController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    
    [HttpPost]
    [Route("")]
    public async Task<CreateApplicationResponseDto> CreateApplication([FromBody] CreateApplicationRequestDto applicationRequestDto)
    {
        var createdApplication = await _applicationService.CreateApplication(applicationRequestDto);
        return createdApplication;
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<UpdateApplicationResponseDto> UpdateApplication([FromRoute] Guid id, [FromBody] UpdateApplicationRequestDto applicationRequestDto)
    {
        var updatedApplication = await _applicationService.UpdateApplication(id, applicationRequestDto);
        return updatedApplication;
    }
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteApplication(Guid id)
    {
        var result = await _applicationService.DeleteApplication(id);
        
        if (result is DeleteResult.Failed)
        {
            return new BadRequestResult(); 
        }

        return new OkObjectResult(result);

    }
    [HttpPost]  
    [Route("{id:guid}/submit")]
    public async Task<IActionResult> SendForSubmitApplication(Guid id)
    {
        var result = await _applicationService.SubmitApplication(id);
        if (result is SubmitResult.Failed)
        {
            return new BadRequestResult();
        }

        return new OkObjectResult(result);
    }
    [HttpGet]
    [Route("submittedAfter")]
    public async Task<IEnumerable<ApplicationDto>> GetApplicationsSendAfter(DateTime submittedAfter)
    {
        var applications = await _applicationService.GetApplicationsSubmittedAfterDate(submittedAfter);
        return applications;
    }
    [HttpGet]
    [Route("unsubmittedOlder")]
    public async Task<IEnumerable<ApplicationDto>> GetApplicationsNotSubmittedAndOlderThanDate(DateTime submittedAfter)
    {
        var applications = await _applicationService.GetApplicationsNotSubmittedAndOlderThanDate(submittedAfter);
        return applications;
    }
    

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ApplicationDto> GetApplicationById(Guid id)
    {
        var currentApplication = await _applicationService.GetApplicationById(id); ;

        return currentApplication;
    }
}