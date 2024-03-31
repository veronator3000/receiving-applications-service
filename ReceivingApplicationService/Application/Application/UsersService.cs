using Contracts;
using HttpDto.Dtos;

namespace Application.Application;

public class UsersService : IUserService
{
    public Task<ResponseDto> GetMyDraftApplication(ApplicationRequestDto applicationRequestDto)
    {
        throw new NotImplementedException();
    }
}