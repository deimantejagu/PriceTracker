using PriceTracker.Models;
using PriceTracker.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PriceTracker.ViewModels
{
    public class GasStationDataViewModel : BaseViewModel
    {
        public ObservableCollection<GasStationDataModel> GasStationData { get; set; }

        private enum GasStationName
        {
            Viada,
            CircleK,
            Neste,
        }

        public GasStationDataViewModel(JsonDataReader jsonDataReader, Filters filters)
        {
            this.jsonDataReader = jsonDataReader;
            this.filters = filters;

            GasStationData = jsonDataReader.GasStationData;

            FilterViadaCommand = new Command(async () => await FilterGasStationsAsync(GasStationName.Viada.ToString()));
            FilterCircleKCommand = new Command(async () => await FilterGasStationsAsync(GasStationName.CircleK.ToString()));
            FilterNesteCommand = new Command(async () => await FilterGasStationsAsync(GasStationName.Neste.ToString()));

            Filter98Command = new Command(async () => await FilterFuelTypesAsync("98"));
            Filter95Command = new Command(async () => await FilterFuelTypesAsync("95"));
            FilterDCommand = new Command(async () => await FilterFuelTypesAsync("D"));
            FilterSNDCommand = new Command(async () => await FilterFuelTypesAsync("SND"));

            UnfilterAllCommand = new Command(async () => await UnfilterAll());
        }

        protected async Task UnfilterAll()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                if (GasStationData.Count != 0)
                {
                    GasStationData.Clear();
                }

                jsonDataReader.GasStationData = jsonDataReader.GetJsonData();
                foreach (var data in jsonDataReader.GasStationData.ToList())
                    GasStationData.Add(data);

                jsonDataReader.GasStationData = GasStationData;
                filters.FilterByNames.Clear();
                filters.FilterByFuelTypes.Clear();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get stations: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
