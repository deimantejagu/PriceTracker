using Newtonsoft.Json;
using PriceTracker.Models;

namespace PriceTracker.PriceScannerOCR
{
    public class DBScanner
    {
        public List<Data> LoadJson()
        {
            string contents = ReadTextFile("prices.json").Result;

            List<Data> workingFromJson = JsonConvert.DeserializeObject<List<Data>>(contents);

            return workingFromJson;
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
