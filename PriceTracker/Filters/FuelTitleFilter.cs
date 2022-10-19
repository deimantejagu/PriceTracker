using PriceTracker.Models;
using System.Runtime.InteropServices.ComTypes;

namespace PriceTracker.Filters
{
    public class FuelTitleFilter
    {
        public List<Data> FilterByTitle(List<Data> dataObjects, string name)
        {
            foreach (Data data in dataObjects)
            {
                int dataIndex = dataObjects.IndexOf(data);

                List<string> Titles = new List<string>();
                List<string> Prices = new List<string>();

                foreach (string title in data.Title)
                {
                    if (title == name)
                    {
                        int index = data.Title.IndexOf(title);
                        Titles.Add(title);

                        for (int i = 0; i < data.Price.Count; i++)
                        {
                            if (i == index)
                            {
                                Prices.Add(data.Price[i]);
                            }
                        }
                    }
                }

                dataObjects[dataIndex].Title = Titles;
                dataObjects[dataIndex].Price = Prices;
            }

            List<Data> filteredData = new List<Data>();

            FilterUnnecessaryData(dataObjects, filteredData);
            foreach (Data data in filteredData)
            {
                _ = dataObjects.Remove(data);
            }

            return dataObjects;
        }

        private List<Data> FilterUnnecessaryData(List<Data> dataObjects, List<Data> filteredData)
        {
            foreach (Data data in dataObjects)
            {
                int dataIndex = dataObjects.IndexOf(data);
                if (dataObjects[dataIndex].Title.Count == 0)
                    filteredData.Add(data);
            }

            return filteredData;
        }
    }
}

