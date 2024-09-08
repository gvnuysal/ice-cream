using Gvn.IceCream.API.Services;
using Gvn.IceCream.Shared.Dtos;

namespace Gvn.IceCream.API.EndPoints;

public static class EndPoints
{
    public static IEndpointRouteBuilder MapEndPoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/signup", async (SignupRequestDto dto, AuthServices authService) =>
                                  TypedResults.Ok(await authService.SignupAsync(dto)));

        app.MapPost("/api/sigin", async (SigninRequestDto dto, AuthServices authService) =>
                                 TypedResults.Ok(await authService.SigninAsync(dto)));
        return app;
    }
}
