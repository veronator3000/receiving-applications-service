using System.Diagnostics;
using System.Net.Mime;
using Entities;
using HttpDto.Dtos;

namespace Contracts;

public interface IApplicationService
{
    Task<ResponseDto> CreateApplication(RequestDto requestDto);
    Task<ResponseDto> UpdateApplication(Guid id, RequestDto requestDto);
    Task<ResponseDto> DeleteApplication(Guid id);
    Task<ResponseDto> SubmitApplication(Guid id);
    Task<IEnumerable<ResponseDto>> GetApplications(DateTime? submitted, DateTime? unsubmitted);
    Task<ResponseDto> GetCurrentApplicationForUser(Guid userId);
    Task<ResponseDto> GetApplicationById(Guid id);
}