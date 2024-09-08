using Gvn.IceCream.Shared.Dtos;
using Refit;

namespace Gvn.IceCream.MAUI.Services;

public interface IAuthApi
{
    [Post("/api/signup")]
    Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto);
    [Post("/api/sigin")]
    Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto);
}
