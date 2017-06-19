using Starcounter;
using WasteTrader.Measurements;
using WasteTrader.Database;

namespace WasteTrader.ViewModels
{
    partial class WasteEntry : Json, IBound<SellWaste>
    {
        public string FormattedEntryTime => Data.EntryTime.Date.ToString("d");

        public string Amount => MeasurementReader.Read((UnitType) Unit, Quantity, (int) UnitMetricPrefixPower).ToString();
                

        [WasteEntry_json.User]
        partial class WasteUser : Json, IBound<Client>
        {

        }
    }
}