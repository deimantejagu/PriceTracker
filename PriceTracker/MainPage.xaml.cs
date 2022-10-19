using PriceTracker.PriceScannerOCR;
using PriceTracker.ViewModels;
using PriceTracker.Models;
using System;
using PriceTracker.Filters;

namespace PriceTracker
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<Data> dataObjects = ReadJson();

            //Cia bus filtravimas
            FuelTitleFilter fuelTitleFilter = new FuelTitleFilter();
            dataObjects = fuelTitleFilter.FilterByTitle(dataObjects, "98");

            StationNameFilter stationNameFilter = new StationNameFilter();
            dataObjects = stationNameFilter.FilterByName(dataObjects, "CircleK");

            BindingContext = new PriceViewModel(dataObjects);
        }
        private List<Data> ReadJson()
        {
            DBScanner dBScanner = new DBScanner();
            List<Data> dataObjects = dBScanner.LoadJson();

            return dataObjects;
        }
    }
}
