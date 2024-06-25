namespace Gvn.IceCream.MAUI.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
 

    private async void signin_button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SigningPage)}");
    }

    private async void signup_button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(SignupPage)}");
    }  
}