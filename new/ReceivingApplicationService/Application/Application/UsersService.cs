using System;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Repositories;
using Contracts;
using HttpDto.Dtos;
using HttpDto.Dtos.ApplicationDto;
using HttpDto.Dtos.ConcreteApplicationDto;
using HttpDto.Mappers.ApplicationMapper;

namespace Application.Application;

public class UsersService : IUserService
{
    private readonly IApplicationRepository _applicationRepository;

    public UsersService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<ApplicationDto> GetMyDraftApplication(Guid idUser)
    {
        var userApplications = await _applicationRepository.GetApplicationsByUserId(idUser);

        var draftApplication = userApplications.FirstOrDefault(app => app.IsDraft != null);
        var applicationDto = ApplicationMapper.MapToApplicationDto(draftApplication);
        return applicationDto;
    }
}