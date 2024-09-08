namespace Gvn.IceCream.Shared.Dtos;

/// <summary>
/// 
/// </summary>
/// <param name="userId"></param>
/// <param name="Name"></param>
/// <param name="Email"></param>
/// <param name="Address"></param>
public record LoggedInUserDto(Guid Id,string Name,string Email,string Address);
