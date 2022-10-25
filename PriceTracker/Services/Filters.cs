using PriceTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceTracker.Services
{
    public class Filters
    {
        public List<GasStationDataModel> FilterByName(ObservableCollection<GasStationDataModel> GasStationData, string gasStationName)
        {
            List<GasStationDataModel> FilteredData = (from GasStationDataModel data in GasStationData
                                                      where data.GasStationName == gasStationName
                                         select data).ToList();

            return FilteredData;
        }

        public List<GasStationDataModel> FilterByTitle(ObservableCollection<GasStationDataModel> StationData, string name)
        {
            List<GasStationDataModel> GasStationData = StationData.ToList();

            foreach (var fuelType in GasStationData.ToList())
            {
                int dataIndex = GasStationData.IndexOf(fuelType);

                foreach (string title in fuelType.Fueltype.ToList())
                {
                    if (title != name)
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
