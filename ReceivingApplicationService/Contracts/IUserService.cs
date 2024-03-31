using HttpDto.Dtos;

namespace Contracts;

public interface IUserService
{
    Task<ResponseDto> GetMyDraftApplication(ApplicationRequestDto applicationRequestDto);
}