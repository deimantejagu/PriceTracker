using PriceTracker.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace PriceTracker.Services
{
    public class Filters
    {
        public List<string> FilterByNames { get; set; }
        public List<string> FilterByFuelTypes { get; set; }

        public Filters()
        {
            FilterByNames = new List<string>();
            FilterByFuelTypes = new List<string>();
        }

        public void ApplyFilters(JsonDataReader jsonDataReader)
        {
            ObservableCollection<GasStationDataModel> GasStationData = jsonDataReader.GetJsonData();
            List<GasStationDataModel> NewList = GasStationData.ToList();

            if (FilterByFuelTypes.Count > 0)
                NewList = FilterByFuelType(GasStationData);

            if (FilterByNames.Count > 0)
                NewList = FilterByName(GasStationData);

            DataSort.SortList(NewList);

            jsonDataReader.GasStationData.Clear();
            foreach (var data in FilterUnnecessaryData(NewList))
            {
                jsonDataReader.GasStationData.Add(data);
            }
        }

        public List<GasStationDataModel> FilterByName(ObservableCollection<GasStationDataModel> GasStationData)
        {
            IEnumerable<GasStationDataModel> FilteredData = 
                GasStationData.Where(item => FilterByNames.Any(name => name == item.GasStationName));

            return FilteredData.ToList();
        }

        public List<GasStationDataModel> FilterByFuelType(ObservableCollection<GasStationDataModel> StationData)
        {
            foreach (var fuelType in StationData.ToList())
            {
                int dataIndex = StationData.IndexOf(fuelType);

                foreach (var title in fuelType.Fueltype.ToList())
                {
                    if (! FilterByFuelTypes.Any(filter => filter == title))
                    {
                        int index = fuelType.Fueltype.IndexOf(title);

                        StationData[dataIndex].Fueltype.Remove(title);
                        StationData[dataIndex].Price.Remove(fuelType.Price[index]);
                    }
                }
            }

            return StationData.ToList();
        }

        private List<GasStationDataModel> FilterUnnecessaryData(List<GasStationDataModel> GasStationData)
        {
            foreach (var fuelType in GasStationData.ToList())
            {
                int dataIndex = GasStationData.IndexOf(fuelType);
                if (GasStationData[dataIndex].Fueltype.Count == 0)
                    GasStationData.Remove(fuelType);
            }

            return GasStationData;
        }
    }
}
