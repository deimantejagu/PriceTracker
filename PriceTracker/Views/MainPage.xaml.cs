
using PriceTracker.ViewModels;

namespace PriceTracker.Views;

public partial class MainPage : ContentPage
{
	public MainPage(GasStationDataViewModel gasStationDataViewModel)
	{
		InitializeComponent();

		BindingContext = gasStationDataViewModel;
	}
}