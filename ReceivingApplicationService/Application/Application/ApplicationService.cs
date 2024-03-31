using Contracts;
using Abstractions;
using Abstractions.Repositories;
using HttpDto.Dtos;
using HttpDto.Mappers;

namespace Application.Application;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly RequestMapper _requestMapper;
    private readonly ResponseMapper _responseMapper;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
        _requestMapper = new RequestMapper();
        _responseMapper = new ResponseMapper();
    }
    
    public async Task<ResponseDto> CreateApplication(ApplicationRequestDto applicationRequestDto)
    {
        var applicationEntity = _requestMapper.MapToApplication(applicationRequestDto);
        var res = _applicationRepository.CreateApplication(applicationEntity);
        var response = _responseMapper.MapToResponseDto(await res);
        return response;
    }

    public async Task<ResponseDto> UpdateApplication(Guid id, ApplicationRequestDto applicationRequestDto)
    {
        var applicationEntity = _requestMapper.MapToApplication(applicationRequestDto);
        var res = _applicationRepository.UpdateApplication(applicationEntity);
        var response = _responseMapper.MapToResponseDto(await res);
        return response;
    }

    public Task<ResponseDto> DeleteApplication(Guid id)
    {
        var appl
    }

    public Task<ResponseDto> SubmitApplication(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ResponseDto>> GetApplications(DateTime? submitted, DateTime? unsubmitted)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto> GetCurrentApplicationForUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseDto> GetApplicationById(Guid id)
    {
        throw new NotImplementedException();
    }
}