using Newtonsoft.Json;
using PriceTracker.Models;
using System.Collections.ObjectModel;

namespace PriceTracker.PriceScannerOCR
{
    //public class JsonScanner
    //{
    //    public List<GasStationDataModel> LoadJson()
    //    {
    //        string contents = ReadTextFile("prices.json").Result;

    //        List<GasStationDataModel> workingFromJson = JsonConvert.DeserializeObject<List<GasStationDataModel>>(contents);

    //        return workingFromJson;
    //    }

    //    private async Task<string> ReadTextFile(string filePath)
    //    {
    //        using Stream fileStream = await FileSystem.Current.OpenAppPackageFileAsync(filePath);
    //        using StreamReader reader = new StreamReader(fileStream);

    //        string result = reader.ReadToEnd();

    //        return result;
    //    }
    //}
}
