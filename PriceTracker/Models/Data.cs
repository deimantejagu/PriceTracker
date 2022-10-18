namespace PriceTracker.Models
{
    public class Data
    {
        public string Name { get; set; }
        public string[] Title { get; set; }
        public string[] Price { get; set; }

        public Data(string name, string[] title, string[] price)
        {
            Name = name;
            Title = title;
            Price = price;
        }

        public void PrintInfo()
        {
            Console.WriteLine("---------------");
            Console.WriteLine(Name);
            Console.WriteLine("Titles:");
            foreach (string t in Title)
            {
                Console.WriteLine(t);
            }

            Console.WriteLine("Prices:");
            foreach (string p in Price)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("---------------");
        }
    }
}
