namespace Gvn.IceCream.Shared.Dtos;

/// <summary>
/// 
/// </summary>
/// <param name="user"></param>
/// <param name="Token"></param>
public record AuthResponseDto(LoggedInUserDto User,string Token);
