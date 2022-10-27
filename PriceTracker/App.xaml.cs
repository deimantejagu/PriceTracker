using PriceTracker.Views;

namespace PriceTracker;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = new NavigationPage(new LoginPage());
    }
}
