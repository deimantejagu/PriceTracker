namespace PriceTracker.Models
{
    public class GasStationDataModel
    {
        public string GasStationName { get; set; }
        public List<string> Fueltype { get; set; }
        public List<string> Price { get; set; }

        public GasStationDataModel(string name, List<string> title, List<string> price)
        {
            GasStationName = name;
            Fueltype = title;
            Price = price;
        }
    }
}
