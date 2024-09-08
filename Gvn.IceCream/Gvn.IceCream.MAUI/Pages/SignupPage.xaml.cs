using Gvn.IceCream.MAUI.ViewModels;

namespace Gvn.IceCream.MAUI.Pages;

public partial class SignupPage : ContentPage
{
	public SignupPage(AuthViewModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }

    private async void SigninLabel_Tapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(SigningPage));
    }
}