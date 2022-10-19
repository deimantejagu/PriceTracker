using PriceTracker.Models;

namespace PriceTracker.ViewModels
{
    public class PriceViewModel
    {
        public PriceViewModel(List<Data> data)
        {
            foreach (var item in data)
            {
                addDataItem(item.Name, item.Title, item.Price);
            }
        }

        public List<Data> data { get; set; } = new List<Data>();

        private void addDataItem(string name, List<string> title, List<string> price)
        {
            data.Add(new Data(name, title, price));
        }

    }
}
