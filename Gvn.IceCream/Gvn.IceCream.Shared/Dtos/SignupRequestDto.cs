namespace Gvn.IceCream.Shared.Dtos;
/// <summary>
/// Kullanıcı kayıt etmek için kullanılan model
/// </summary>
/// <param name="Name"></param>
/// <param name="Email"></param>
/// <param name="Password"></param>
/// <param name="Address"></param>
public record SignupRequestDto(string Name,string Email,string Password, string Address);
