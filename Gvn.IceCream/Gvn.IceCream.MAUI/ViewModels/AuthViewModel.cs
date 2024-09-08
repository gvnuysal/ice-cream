using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Gvn.IceCream.MAUI.Pages;
using Gvn.IceCream.MAUI.Services;
using Gvn.IceCream.Shared.Dtos;

namespace Gvn.IceCream.MAUI.ViewModels;

public partial class AuthViewModel(IAuthApi authApi) : BaseViewModel
{
    private IAuthApi _authApi=authApi;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _name;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _email;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignin)), NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _password;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CanSignup))]
    private string? _address;
    public bool CanSignup => CanSignin &&
                             !string.IsNullOrEmpty(Password) &&
                             !string.IsNullOrEmpty(Address);
    public bool CanSignin => !string.IsNullOrEmpty(Email) &&
                            !string.IsNullOrEmpty(Password);
    [RelayCommand]
    private async Task SignupAsync()
    {
        IsBusy = true;
        try
        {
            var signupDto = new SignupRequestDto(Name, Email, Password, Address);
            var result = await _authApi.SignupAsync(signupDto);
            if (result.IsSucces)
            {
                await ShowAlertAsync(result.Data.Token);
                await GoToAsync($"//{nameof(HomePage)}",animate:true);
                //redirect home page
            }
            else
            {
                await ShowErrorAlertAsync(result.ErrorMessage??"UnKnown error in signing up");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);

        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private async Task SigningAsync()
    {
        IsBusy = true;
        try
        {
            var sigingDto = new SigninRequestDto(Email,Password);
            var result = await _authApi.SigninAsync(sigingDto);
            if (result.IsSucces)
            {
                await ShowAlertAsync(result.Data.User.Name);
                await GoToAsync($"//{nameof(HomePage)}", animate: true);
                //redirect home page
            }
            else
            {
                await ShowErrorAlertAsync(result.ErrorMessage ?? "UnKnown error in signing up");
            }
        }
        catch (Exception ex)
        {
            await ShowErrorAlertAsync(ex.Message);

        }
        finally
        {
            IsBusy = false;
        }
    }
}
