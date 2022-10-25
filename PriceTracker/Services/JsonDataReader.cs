using Newtonsoft.Json;
using PriceTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceTracker.Services
{
    public class JsonDataReader
    {
        public ObservableCollection<GasStationDataModel> GasStationData { get; set; }

        public JsonDataReader()
        {
            GasStationData = new ObservableCollection<GasStationDataModel>();
            GasStationData = GetMonkeys();
        }

        public ObservableCollection<GasStationDataModel> GetMonkeys()
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
