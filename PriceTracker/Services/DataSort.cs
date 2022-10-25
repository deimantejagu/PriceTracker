using PriceTracker.Models;

namespace PriceTracker.Services
{
    public class DataSort
    {
        public List<GasStationDataModel> SortList(List<GasStationDataModel> gasStationData)
        {
            //gasStationData.Sort((p1, p2) => p1.Price.CompareTo(p2.Price));
            //gasStationData.Sort(delegate (GasStationDataModel c1, GasStationDataModel c2) { return c1.Price.CompareTo(c2.Price); });

            return gasStationData;
        }
    }
}
