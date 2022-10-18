using Newtonsoft.Json;
using PriceTracker.Models;

namespace PriceTracker.PriceScannerOCR
{
    public class DBScanner
    {
        public Data[] LoadJson()
        {

            //using var stream = await FileSystem.OpenAppPackageFileAsync("prices.json");
            //using var reader = new StreamReader(stream);

            //var contents = reader.ReadToEnd();

            //string contents = File.ReadAllText("prices.json");

            //string contents = ReadTextFile("prices.json");

            //Task<string> readPrices = ReadTextFile("prices.json");

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
