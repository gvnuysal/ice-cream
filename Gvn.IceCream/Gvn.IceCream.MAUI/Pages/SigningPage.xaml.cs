using Gvn.IceCream.MAUI.ViewModels;

namespace Gvn.IceCream.MAUI.Pages;

public partial class SigningPage : ContentPage
{
	public SigningPage(AuthViewModel authViewModel)
	{
		InitializeComponent();
		BindingContext = authViewModel;
	}

  

    private async void SignupLabel_Tapped(object sender, TappedEventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(SignupPage));
    }
}