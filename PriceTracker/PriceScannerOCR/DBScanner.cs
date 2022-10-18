using Newtonsoft.Json;
using PriceTracker.PriceScannerOCR;

namespace PriceTracker.PriceScannerOCR
{
    public class DBScanner
    {
        public void LoadJson()
        {
            string fileName = "prices.json";
            string jsonString = File.ReadAllText(fileName);
            //Data data = JsonSerializer.Deserialize<Data>(jsonString)!;

            //Console.WriteLine($"Name: {data.Name}");
            //Console.WriteLine($"Title: {data.Title}");
            //Console.WriteLine($"Price: {data.Price}");

            Console.WriteLine(jsonString);
        }
    }
}
