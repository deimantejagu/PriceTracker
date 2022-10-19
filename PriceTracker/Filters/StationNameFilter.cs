using PriceTracker.Models;

namespace PriceTracker.Filters
{
    public class StationNameFilter
    {
        public List<Data> FilterByName(List<Data> dataObjects, string name)
        {
            List<Data> filteredData = (from Data data in dataObjects
                                        where data.Name != name
                                        select data).ToList();

            foreach (Data data in filteredData)
            {
                _ = dataObjects.Remove(data);
            }

            return dataObjects;
        }
    }
}
