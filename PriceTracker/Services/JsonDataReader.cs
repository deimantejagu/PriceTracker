using Newtonsoft.Json;
using PriceTracker.Models;
using System.Collections.ObjectModel;

namespace PriceTracker.Services
{
    public class JsonDataReader
    {
        public ObservableCollection<GasStationDataModel> GasStationData { get; set; }

        public JsonDataReader()
        {
            GasStationData = new ObservableCollection<GasStationDataModel>();
            GasStationData = GetJsonData();
        }

        public ObservableCollection<GasStationDataModel> GetJsonData()
        {
            string contents = ReadTextFile("prices.json").Result;

            ObservableCollection<GasStationDataModel> desiarilzedJson= JsonConvert.DeserializeObject<ObservableCollection<GasStationDataModel>>(contents);

            return desiarilzedJson;
        }

        private async Task<string> ReadTextFile(string filePath)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);

            string result = reader.ReadToEnd();

            return result;
        }
    }
}
