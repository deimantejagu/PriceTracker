using PriceTracker.Models;
using PriceTracker.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PriceTracker.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        bool isBusy;
        string title;

        protected JsonDataReader jsonDataReader;
        protected Filters filters;

        public Command FilterViadaCommand { get; set; }
        public Command FilterCircleKCommand { get; set; }
        public Command FilterNesteCommand { get; set; }
        public Command UnfilterAllCommand { get; set; }

        public Command Filter98Command { get; set; }
        public Command Filter95Command { get; set; }
        public Command FilterDCommand { get; set; }
        public Command FilterSNDCommand { get; set; }

        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy == value)
                {
                    return;
                }

                isBusy = value;
                OnPropertyChanged();

                OnPropertyChanged(nameof(IsNotBusy));
            }
        }

        public string Title
        {
            get => title;
            set
            {
                if (title == value)
                {
                    return;
                }

                title = value;
                OnPropertyChanged();
            }
        }

        protected async Task FilterGasStationsAsync(string name)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                filters.FilterByNames.Add(name);

                filters.ApplyFilters(jsonDataReader);

                //List<GasStationDataModel> Data = filters.FilterByName(jsonDataReader.GetJsonData());
                //jsonDataReader.GasStationData.Clear();
                //foreach (var data in Data.ToList())
                //{
                //    jsonDataReader.GasStationData.Add(data);
                //}
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

        protected async Task FilterFuelTypesAsync(string name)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                filters.FilterByFuelTypes.Add(name);

                //filters.ApplyFilters()

                filters.ApplyFilters(jsonDataReader);

                //List<GasStationDataModel> Data = filters.FilterByTitleMultiple(jsonDataReader.GetJsonData());

                //jsonDataReader.GasStationData.Clear();
                //foreach (var data in Data.ToList())
                //{
                //    jsonDataReader.GasStationData.Add(data);
                //}
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

        public bool IsNotBusy => !IsBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
