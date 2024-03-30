using Contracts;
using HttpDto.Dtos;
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

    [HttpGet]
    [Route("{id:guid}")]
    public string Get(int id)
    {
        return id.ToString();
    }
    
    [HttpPost]
    [Route("")]
    public async Task<ResponseDto> CreateApplication([FromBody] RequestDto requestDto)
    {
        var createdApplication = await _applicationService.CreateApplication(requestDto);
        return createdApplication;
    }
    
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<ResponseDto> UpdateApplication([FromRoute] Guid id, [FromBody] RequestDto requestDto)
    {
        var updatedApplication = await _applicationService.UpdateApplication(id, requestDto);
        return updatedApplication;
    }
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<ResponseDto> DeleteApplication(Guid id)
    {
        return await _applicationService.DeleteApplication(id);
    }
    
    [HttpPost]  
    [Route("{id:guid}/submit")]
    public async Task<ResponseDto> SendForSubmitApplication(Guid id)
    {
        return await _applicationService.SubmitApplication(id);
    }
    [HttpGet]
    public async Task<IEnumerable<ResponseDto>> GetApplications(DateTime? submittedAfter, DateTime? unsubmittedOlder)
    {
        var applications = await _applicationService.GetApplications(submittedAfter, unsubmittedOlder);
        return applications;
    }

    [HttpGet]
    [Route("users/{userId:guid}/currentapplication")]
    public async Task<ResponseDto> GetCurrentApplicationForUser(Guid userId)
    {
        var currentApplication = await _applicationService.GetCurrentApplicationForUser(userId); ;

        return currentApplication;
    }
}