using PriceTracker.Services;

namespace PriceTracker.ViewModels
{
    public class FilterViewModel : GasStationDataViewModel
    {
        public FilterViewModel(JsonDataReader jsonDataReader, Filters filters) : base(jsonDataReader, filters)
        {
        }
    }
}
