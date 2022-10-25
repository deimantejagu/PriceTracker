using PriceTracker.ViewModels;

namespace PriceTracker.Views;

public partial class FilterPage : ContentPage
{
	public FilterPage(FilterViewModel filterViewModel)
	{
		InitializeComponent();

		BindingContext = filterViewModel;
	}
}