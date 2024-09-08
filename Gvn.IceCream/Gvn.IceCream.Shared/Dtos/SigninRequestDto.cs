namespace Gvn.IceCream.Shared.Dtos;

/// <summary>
/// login işlemi için kullanılan model
/// </summary>
/// <param name="Email"></param>
/// <param name="Password"></param>
public record SigninRequestDto(string Email, string Password);
