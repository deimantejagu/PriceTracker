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

            FilterViadaCommand = new Command(async () => await FilterMonkeysAsync(GasStationName.Viada.ToString()));
            FilterCircleKCommand = new Command(async () => await FilterMonkeysAsync(GasStationName.CircleK.ToString()));
            FilterNesteCommand = new Command(async () => await FilterMonkeysAsync(GasStationName.Neste.ToString()));

            Filter98Command = new Command(async () => await FilterMonkeysTypesAsync("98"));
            Filter95Command = new Command(async () => await FilterMonkeysTypesAsync("95"));
            FilterDCommand = new Command(async () => await FilterMonkeysTypesAsync("D"));
            FilterSNDCommand = new Command(async () => await FilterMonkeysTypesAsync("SND"));

            UnfilterAllCommand = new Command(async () => await UnfilterAllMonkeysAsync());
        }

        protected async Task UnfilterAllMonkeysAsync()
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

                jsonDataReader.GasStationData = jsonDataReader.GetMonkeys();
                foreach (var data in jsonDataReader.GasStationData.ToList())
                    GasStationData.Add(data);

                jsonDataReader.GasStationData = GasStationData;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
