using System;
using System.Threading.Tasks;
using HttpDto.Dtos;
using HttpDto.Dtos.ApplicationDto;
using HttpDto.Dtos.ConcreteApplicationDto;

namespace Contracts;

public interface IUserService
{
    Task<ApplicationDto> GetMyDraftApplication(Guid idUser);
}