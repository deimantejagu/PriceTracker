using PriceTracker.Models;

namespace PriceTracker.ViewModels
{
    public class PriceViewModel
    {
        public PriceViewModel(Data[] data)
        {
            foreach (var item in data)
            {
                addDataItem(item.Name, item.Title, item.Price);
            }
        }

        private void addDataItem(string name, string[] title, string[] price)
        {
            data.Add(new Data(name, title, price));
        }

        public List<Data> data { get; set; } = new List<Data>();
    }
}
