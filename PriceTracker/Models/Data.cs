namespace PriceTracker.Models
{
    public class Data
    {
        public string Name { get; set; }
        public List<string> Title { get; set; }
        public List<string> Price { get; set; }

        public Data(string name, List<string> title, List<string> price)
        {
            Name = name;
            Title = title;
            Price = price;
        }
    }
}
