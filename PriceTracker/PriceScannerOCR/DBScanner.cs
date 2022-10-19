using Newtonsoft.Json;
using PriceTracker.Models;

namespace PriceTracker.PriceScannerOCR
{
    public class DBScanner
    {
        public Data[] LoadJson()
        {
            string contents = ReadTextFile("prices.json").Result;

            Data[] workingFromJson = JsonConvert.DeserializeObject<Data[]>(contents);
            foreach (Data data in workingFromJson)
            {
                data.PrintInfo();
            }

            return workingFromJson;
        }

        private async Task<string> ReadTextFile(string filePath)
        {
            using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
            using StreamReader reader = new StreamReader(fileStream);

            // Works, but dont know why!? And how :D
            string result = reader.ReadToEnd();

            return result;
        }
    }
}
