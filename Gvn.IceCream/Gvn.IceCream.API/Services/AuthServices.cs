using Gvn.IceCream.API.Data;
using Gvn.IceCream.API.Data.Entities;
using Gvn.IceCream.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Gvn.IceCream.API.Services;

public class AuthServices(DataContext context, TokenServices tokenServices, PasswordServices passwordServices)
{
    private readonly DataContext _context = context;
    private readonly TokenServices _tokenServices = tokenServices;
    private readonly PasswordServices _passwordServices = passwordServices;
    public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
    {

        if (await _context.Users.AsNoTracking().AnyAsync(x => x.Email == dto.Email))
        {
            return ResultWithDataDto<AuthResponseDto>.Failure("Email already exists");
        }

        var user = new User
        {
            Address = dto.Address,
            Email = dto.Email,
            Name = dto.Name
        };
        (user.Salt, user.Hash) = _passwordServices.GenerateSaltedHash(dto.Password);
        try
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return GenerateAuthResponse(user);
        }
        catch (Exception ex)
        {
            return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
        }
    }

    private ResultWithDataDto<AuthResponseDto> GenerateAuthResponse(User user)
    {
        var loggedUser = new LoggedInUserDto(user.Id,
                                           user.Name,
                                           user.Email,
                                           user.Address);
        var token = _tokenServices.GenerateJwt(loggedUser);
        var authResponse = new AuthResponseDto(loggedUser, token);

        return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
    }

    public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
    {
        var dbUser=await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == dto.Email);
        if (dbUser is null)
        {
            return ResultWithDataDto<AuthResponseDto>.Failure("User not found");
        }
        if(!_passwordServices.AreEqual(dto.Password, dbUser.Salt, dbUser.Hash))
        {
            return ResultWithDataDto<AuthResponseDto>.Failure("Password is wrong");
        }

        return GenerateAuthResponse(dbUser);
    }
}
