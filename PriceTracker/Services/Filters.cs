using PriceTracker.Models;
using System.Collections.ObjectModel;

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

        public void ApplyFilters(ObservableCollection<GasStationDataModel> GasStationData, JsonDataReader jsonDataReader)
        {
            //List<GasStationDataModel> Data = jsonDataReader.GetJsonData();

            // Gauti duomenu lista observable ir paleist pro filtrus

            if (FilterByFuelTypes.Count > 0)
                FilterByFuelType(GasStationData);

            if (FilterByNames.Count > 0)
                FilterByName(GasStationData);

            List<GasStationDataModel> Data = FilterByFuelType(jsonDataReader.GetJsonData());
            //jsonDataReader.GasStationData.Clear();
            foreach (var data in Data.ToList())
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
            List<GasStationDataModel> GasStationData = StationData.ToList();

            foreach (var fuelType in GasStationData.ToList())
            {
                int dataIndex = GasStationData.IndexOf(fuelType);

                foreach (var title in fuelType.Fueltype.ToList())
                {
                    if (! FilterByFuelTypes.Any(filter => filter == title))
                    {
                        int index = fuelType.Fueltype.IndexOf(title);

                        GasStationData[dataIndex].Fueltype.Remove(title);
                        GasStationData[dataIndex].Price.Remove(fuelType.Price[index]);
                    }
                }
            }

            return FilterUnnecessaryData(GasStationData);
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
