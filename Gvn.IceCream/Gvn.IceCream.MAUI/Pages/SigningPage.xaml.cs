namespace Gvn.IceCream.MAUI.Pages;

public partial class SigningPage : ContentPage
{
	public SigningPage()
	{
		InitializeComponent();
	}

    private void gotoApp_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync($"//{nameof(HomePage)}");
    }
}