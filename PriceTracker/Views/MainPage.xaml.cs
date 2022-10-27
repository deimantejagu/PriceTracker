
using PriceTracker.ViewModels;

namespace PriceTracker.Views;

public partial class MainPage : ContentPage
{
    public MainPage(GasStationDataViewModel gasStationDataViewModel)
    {
        InitializeComponent();

        BindingContext = gasStationDataViewModel;
    }

    private async void Add_Image_Button_Clicked(object sender, EventArgs e)
    {
        var customFileTypes = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            {DevicePlatform.Android, new[] { "image/jpeg", "image/png", "image/jpg"}}
        });

        IEnumerable<FileResult> results = await FilePicker.PickMultipleAsync(new PickOptions
        {
            FileTypes = customFileTypes
        });

        foreach (var result in results)
        {
            var kintamasis = result.FullPath;
            await DisplayAlert("You picked: ", result.FileName, "OK");
        }
    }
}