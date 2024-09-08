namespace Gvn.IceCream.Shared.Dtos;

/// <summary>
/// 
/// </summary>
/// <param name="IsSuccess"></param>
/// <param name="ErrorMessage"></param>
public record ResultDto(bool IsSuccess, string? ErrorMessage)
{
    public static ResultDto Success() => new ResultDto(true, null);
    public static ResultDto Failure(string? errorMessage) => new ResultDto(false, errorMessage); 
}
