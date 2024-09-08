using Gvn.IceCream.Shared.Dtos;
using System.Text.Json;

namespace Gvn.IceCream.MAUI.Services;

public class AuthServices
{
    private const string AuthKey = "AuthKey";
    public LoggedInUserDto User { get; private set; }
    public string? Token { get; private set; }
    public void Signin(AuthResponseDto dto)
    {
        var serialized = JsonSerializer.Serialize(dto);
        Preferences.Default.Set(AuthKey, serialized);
        (User, Token) = dto;
    }
    public void Signout()
    {
        Preferences.Default.Remove(AuthKey);
    }
}
