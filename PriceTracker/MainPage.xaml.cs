using PriceTracker.PriceScannerOCR;
using PriceTracker.ViewModels;
using PriceTracker.Models;

namespace PriceTracker
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Data[] dataObjects = ReadJson();
            BindingContext = new PriceViewModel(dataObjects);
        }
        public Data[] ReadJson()
        {
            DBScanner dBScanner = new DBScanner();
            Data[] dataObjects = dBScanner.LoadJson();

            return dataObjects;
        }
    }
}
