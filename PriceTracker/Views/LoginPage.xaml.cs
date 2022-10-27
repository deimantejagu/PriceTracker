using PriceTracker.ViewModels;

namespace PriceTracker.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{	
		await Navigation.PushAsync(new NavigationPage(new AppShell()));
    }
}