using PriceTracker.Models;

namespace PriceTracker.Services
{
    public class DataSort
    {
        public static void SortList(List<GasStationDataModel> GasStationData)
        {
            for (var i = 0; i < GasStationData.Count - 1; i++)
            {
                for (var j = 0; j < GasStationData.Count - i - 1; j++)
                {
                    var price1 = ConvertToDouble(GasStationData, j);
                    var price2 = ConvertToDouble(GasStationData, j + 1);
                    if (price1 > price2)
                    {
                        var temp = GasStationData[j];
                        GasStationData[j] = GasStationData[j + 1];
                        GasStationData[j + 1] = temp;
                    }
                }
            }

        }

        private static double ConvertToDouble(List<GasStationDataModel> GasStationData, int objectIndex)
        {
            if (GasStationData[objectIndex].Price.Count > 0)
                return Convert.ToDouble(GasStationData[objectIndex].Price[0]);

            return 0;
        }
    }
}
