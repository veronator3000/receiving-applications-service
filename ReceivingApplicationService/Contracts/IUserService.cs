using HttpDto.Dtos;

namespace Contracts;

public interface IUserService
{
    Task<ResponseDto> GetMyDraftApplication(RequestDto requestDto);
}