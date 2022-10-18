using PriceTracker.PriceScannerOCR;

namespace PriceTracker
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            readJson();
        }

        public void readJson()
        {
            DBScanner dBScanner = new DBScanner();
            dBScanner.LoadJson();
        }
    }
}

